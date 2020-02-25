using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Singleton
{
    class DaoSingletonUnsafe
    {
        private static DaoSingletonUnsafe _instance = null;

        private DaoSingletonUnsafe()
        {
        }

        public static DaoSingletonUnsafe Instance
        {
            get
            {
                Console.WriteLine($"Before checking for null. Thread: {Thread.CurrentThread.Name}");
                if(_instance == null)
                {
                    Console.WriteLine($"Inside if. a new instancw will be created. Thread: {Thread.CurrentThread.Name}");
                    _instance = new DaoSingletonUnsafe();
                }
                return _instance;
            }
        }
    }
}
