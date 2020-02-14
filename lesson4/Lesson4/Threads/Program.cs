using System;
using System.Threading;

namespace Threads 
{
    class Program
    {
        static void Main(string[] args)
        {

            Test test = new Test();
            Test test1 = new Test();

            Thread th = new Thread(new ThreadStart(() => 
            {
                for (int i = 0; i < 10; i++) {
                    Console.WriteLine($"Custom thread th:\t\ti = {i}");
                    Thread.Sleep(500);
                }
            }));

            Thread th1 = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 12; i++) {
                    Console.WriteLine($"Custom thread th1:\t\ti = {i}");
                    Thread.Sleep(1000);
                }
            }));

            th.Start();
            th1.Start();

            for (int i = 0; i < 10; i++) 
            {
                Console.WriteLine($"Main thread:\t\ti = {i}");
                Thread.Sleep(800);
            }
        }
    }
}
