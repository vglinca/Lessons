using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Lesson13
{
    class Program
    {
        private static string dir1Path = @"D:\dev\Amdaris_lessons\dir1";
        //@"D:\dir1";
        private static string dir2Path = @"D:\dev\Amdaris_lessons\dir2";
            //@"D:\dir2";
        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();

            try
            {
                watcher.Path = dir1Path;
            } catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                return;
            }

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite |
                NotifyFilters.FileName | NotifyFilters.DirectoryName;

            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;

            watcher.EnableRaisingEvents = true;


            Console.WriteLine($"Press \"q\" to quit app.");
            while (Console.Read() != 'q') ;
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            //get name of created file first, not path. Example: text.txt
            var fileName = Path.GetFileName(e.FullPath);
            //combine created file name with second directory path
            //i.e. dir2 + fileName. newFilePath contains full path to new file in dir2
            //which will be created
            var newFilePath = Path.Combine(dir2Path, fileName);
            //create file in second directory if it does not exist there.
            if (!File.Exists(newFilePath))
            {
                Console.WriteLine($"File with path {fileName} doesn't exists in {dir2Path}");
                Console.WriteLine($"Creating file \"{newFilePath}\"");
                CreateFileInDir2(newFilePath, e.FullPath);
            }
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            //retrieve old and new paths
            var oldPath = Path.GetFileName(e.OldFullPath);
            var newPath = Path.GetFileName(e.FullPath);
            RenameFileInDir2(oldPath, newPath);
        }

        static void OnChanged(object sender, FileSystemEventArgs e)
        {
            //retrieve name of changed file
            var fileName = Path.GetFileName(e.FullPath);
            //we wait until changed file is locked to prevent exception
            while (IsFileLocked(e.FullPath)) ;
            //while (FilesLockedInDirectory(dir1Path)) ;

            //now we can go further
            Console.WriteLine($"File {fileName} is unlocked.");
            //compute hash for changed file from dir1
            var dir1FileHash = CheckMD5(e.FullPath);
            //create path for changed file in dir2 and check if such file exists
            var dir2FilePath = Path.Combine(dir2Path, fileName);
            if (File.Exists(dir2FilePath) && dir1FileHash != null)
            {
                while (IsFileLocked(dir2FilePath)) ;
                //while (FilesLockedInDirectory(dir2Path)) ;
                //now we can compute hash for equivalent file in dir2
                var dir2FileHash = CheckMD5(dir2FilePath);
                //and check if file has been actually changed
                if (!dir1FileHash.Equals(dir2FileHash))
                {
                    //delete file with old content and recreate it
                    File.Delete(dir2FilePath);
                    CreateFileInDir2(dir2FilePath, e.FullPath);
                } else
                {
                    Console.WriteLine($"Nothing to change. File \"{dir2FilePath}\" is up to date.");
                }
            } else
            {
                Console.WriteLine($"Could not find file \"{fileName}\"");
            }
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            //get deleted file path
            var fileName = Path.GetFileName(e.FullPath);
            //retrieve path of equivalent file from dir2 and check if it exists
            var fileInDir2ToDelPath = Path.Combine(dir2Path, fileName);
            if (File.Exists(fileInDir2ToDelPath))
            {
                File.Delete(fileInDir2ToDelPath);
                Console.WriteLine($"File \"{fileName}\" has successfully been deleted in {dir2Path}.");
            } else
            {
                Console.WriteLine($"Could not find file \"{fileName}\" in {dir2Path}");
            }
        }

        private static async void CreateFileInDir2(string destPath, string srcPath)
        {
            //destPath is the full path of a new file in dir2 which will be created here.
            //srcPath is the full path of a created file in dir2
            //wait until file is locked by another process
            while (IsFileLocked(srcPath)) ;
            while (IsFileLocked(destPath)) ;
            //while (FilesLockedInDirectory(dir1Path)) ;
            //while (FilesLockedInDirectory(dir2Path)) ;
            
            using var inStream = new FileStream(srcPath, FileMode.OpenOrCreate);
            using var reader = new StreamReader(inStream);
            using var outStream = new FileStream(destPath, FileMode.Create);
            using var writer = new StreamWriter(outStream);
            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                await writer.WriteLineAsync(line);
            }
        }
        private static void RenameFileInDir2(string oldPath, string newPath)
        {
            var newFileName = Path.GetFileName(newPath);
            var oldFileName = Path.GetFileName(oldPath);
            //additional checks for existing files in dir2
            if (File.Exists(Path.Combine(dir2Path, oldFileName)) &&
                !File.Exists(Path.Combine(dir2Path, newFileName)))
            {
                File.Move(Path.Combine(dir2Path, oldFileName), Path.Combine(dir2Path, newFileName));
                Console.WriteLine($"\"{Path.Combine(dir2Path, oldFileName)}\" renamed to \"{Path.Combine(dir2Path, newFileName)}\"");
            }
        }

        private static string CheckMD5(string filename)
        {
            if (File.Exists(filename))
            {
                while (IsFileLocked(filename)) ;
                using var md5 = MD5.Create();
                using var stream = File.OpenRead(filename);
                return Encoding.Default.GetString(md5.ComputeHash(stream));
            } else
            {
                return null;
            }
        }

        //private static bool IsTemporaryFile(string filepath)
        //{
        //    var extension = Path.GetExtension(filepath);
        //    return extension == ".tmp";
        //}

        private static bool FilesLockedInDirectory(string directory)
        {
            var files = Directory.EnumerateFiles(directory);
            foreach (var f in files)
            {
                if (IsFileLocked(f))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsFileLocked(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    using FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None);
                    stream.Close();
                }
            } catch (Exception)
            {
                return true;
            }
            return false;
        }
    }
}
