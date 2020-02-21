using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13
{
    class Program
    {
        private static string dir1Path = @"D:\dir1";
        private static string dir2Path = @"D:\dir2";
        private static int i = 1;
        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();

            DirectoryInfo dir1 = new DirectoryInfo(dir1Path);
            DirectoryInfo dir2 = new DirectoryInfo(dir2Path);

            try
            {
                watcher.Path = @"D:\dir1";
            } 
            catch (Exception e)
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

            var fileName = Path.GetFileName(e.FullPath);
            var newFilePath = Path.Combine(dir2Path, fileName);

                if (!File.Exists(newFilePath))
                {
                    Console.WriteLine($"File with path {newFilePath} doesn't exists in {dir2Path}");
                    CreateFileInDir2(newFilePath, e.FullPath);
                }
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            var oldPath = Path.GetFileName(e.OldFullPath);
            var newPath = Path.GetFileName(e.FullPath);
            RenameFileInDir2(oldPath, newPath);
        }

        static void OnChanged(object sender, FileSystemEventArgs e)
        {
            var fileName = Path.GetFileName(e.FullPath);
            var dir1FileHash = CheckMD5(e.FullPath);
            var dir2FilePath = Path.Combine(dir2Path, fileName);
            if (File.Exists(dir2FilePath))
            {
                var dir2FileHash = CheckMD5(dir2FilePath);
                if (!dir1FileHash.Equals(dir2FileHash))
                {
                    File.Delete(dir2FilePath);
                    CreateFileInDir2(dir2FilePath, e.FullPath);
                } 
                else
                {
                    Console.WriteLine("Nothing to change.");
                }
            } 
            else
            {
                Console.WriteLine($"Could not find file {fileName}");
            }
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            var fileName = Path.GetFileName(e.FullPath);
            var fileToDelPath = Path.Combine(dir2Path, fileName);
            if (File.Exists(fileToDelPath))
            {
                File.Delete(fileToDelPath);
            } 
            else
            {
                Console.WriteLine($"Could not find file {fileName}");
            }
        }

        private static async void CreateFileInDir2(string path, string srcPath)
        {
            using var inStream = new FileStream(srcPath, FileMode.Open);
            using var reader = new StreamReader(inStream);
            using var outStream = new FileStream(path, FileMode.Create);
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
            File.Move(Path.Combine(dir2Path, oldFileName), Path.Combine(dir2Path, newFileName));
        }

        private static string CheckMD5(string filename)
        {
            using var md5 = MD5.Create();
            using var stream = File.OpenRead(filename);
            return Encoding.Default.GetString(md5.ComputeHash(stream));
        }
    }
}
