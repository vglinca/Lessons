using System;
using System.Threading;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //WithThreadSafe();
            WithThreadUnsafe();
        }
        
        private static void WithThreadSafe()
        {
            var th1 = new Thread(GetThreadsafeSingleton);
            var th2 = new Thread(GetThreadsafeSingleton);
            var th3 = new Thread(GetThreadsafeSingleton);
            var th4 = new Thread(GetThreadsafeSingleton);

            th1.Name = "A";
            th2.Name = "B";
            th3.Name = "C";
            th4.Name = "D";

            th1.Start();
            th2.Start();
            th3.Start();
            th4.Start();
        }

        private static void WithThreadUnsafe()
        {
            var th1 = new Thread(GetThreadUnsafeSingleton);
            var th2 = new Thread(GetThreadUnsafeSingleton);
            var th3 = new Thread(GetThreadUnsafeSingleton);
            var th4 = new Thread(GetThreadUnsafeSingleton);

            th1.Name = "W";
            th2.Name = "X";
            th3.Name = "Y";
            th4.Name = "Z";

            th1.Start();
            th2.Start();
            th3.Start();
            th4.Start();
        }

        static void GetThreadsafeSingleton()
        {
            var singleton = DaoSingleton.GetInstance();
            Console.WriteLine($"Thread: {Thread.CurrentThread.Name}\tSingleton: {singleton.GetHashCode()}");
        }

        static void GetThreadUnsafeSingleton()
        {
            var singleton = DaoSingletonUnsafe.Instance;
            Console.WriteLine($"Thread: {Thread.CurrentThread.Name}\tSingleton: {singleton.GetHashCode()}");
        }
    }
}
