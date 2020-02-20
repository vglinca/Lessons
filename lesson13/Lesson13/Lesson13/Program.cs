using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13
{
    class Program
    {
        private static StringBuilder dir1Path = new StringBuilder(@"D:\dir1");
        private static StringBuilder dir2Path = new StringBuilder(@"D:\dir2");
        private static int i = 1;
        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();

            DirectoryInfo dir1 = new DirectoryInfo(dir1Path.ToString());
            DirectoryInfo dir2 = new DirectoryInfo(dir2Path.ToString());

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
            watcher.Renamed += (s, e) => Console.WriteLine($"File: \"{e.OldFullPath}\" renamed to \"{e.FullPath}\"");

            watcher.EnableRaisingEvents = true;



            Console.WriteLine($"Press \"q\" to quit app.");
            while (Console.Read() != 'q') ;
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: \"{e.FullPath}\". Change type: {e.ChangeType}");

                var filePathSplit = e.FullPath.Split('\\');
                var fileName = filePathSplit[filePathSplit.Length - 1];

                var path = dir2Path.ToString() + "\\" + fileName;
                if (!File.Exists(path))
                {
                    Console.WriteLine($"File with path {path} doesn't exists in {dir2Path.ToString()}");
                    CreateFileInDir2(path, e.FullPath);
                }
        }

        static void OnChanged(object sender, FileSystemEventArgs e)
        {
            
        }

        private static async void CreateFileInDir2(string path, string srcPath)
        {
            //File.Create(path).Dispose();
            //if (!IsFileLocked(path))
            //{
            //using var writeStream = File.Create(path);
            //using var writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
            //using FileStream stream = File.OpenRead(srcPath);
            //using var writeStream = File.OpenWrite(path);
            //BinaryReader reader = new BinaryReader(stream);
            //BinaryWriter writer = new BinaryWriter(writeStream);

            //var buf = new byte[1024];
            //int bytesRead;

            //while ((bytesRead = await stream.ReadAsync(buf, 0, 1024)) > 0)
            //{
            //    await writeStream.WriteAsync(buf, 0, bytesRead);
            //}
            // }

            using var fsW = new FileStream(path, FileMode.CreateNew);
            using var fsR = new FileStream(srcPath, FileMode.Open, FileAccess.Read);
            using var reader = new BinaryReader(fsR);
            using var writer = new BinaryWriter(fsW);
            var buf = new byte[1024];
            int bytesRead;
            while ((bytesRead = await fsR.ReadAsync(buf, 0, 1024)) > 0)
            {
                await fsW.WriteAsync(buf, 0, bytesRead);
            }
        }

        static bool IsFileLocked(string path)
        {
            try
            {
                using (var stream = new FileStream(path, FileMode.Open)) ;
                return true;
            } 
            catch (Exception)
            {
                return false;
            }
        }
    }
}
