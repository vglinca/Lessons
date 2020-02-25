
using System.Collections.Generic;
using System.Threading;

namespace Singleton
{
    class DaoSingleton
    {
        private static volatile DaoSingleton _instance = null;

        private static readonly object key = new object();

        private static List<string> _collection;

        private DaoSingleton()
        {
            _collection = new List<string>();
        }

        //public static DaoSingleton Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            lock (key)
        //            {
        //                if (_instance == null)
        //                {
        //                    _instance = new DaoSingleton();
        //                }
        //            }
        //        }
        //        return _instance;
        //    }
        //}

        public static DaoSingleton GetInstance()
        {
            if(_instance == null)
            {
                System.Console.WriteLine($"In if(). before lock(). Thread: {Thread.CurrentThread.Name}");
                lock (key)
                {
                    System.Console.WriteLine($"In lock(). Before if(). Thread: {Thread.CurrentThread.Name}");
                    if(_instance == null)
                    {
                        System.Console.WriteLine($"In lock() and inside the last if(). Thread: {Thread.CurrentThread.Name}");
                        _instance = new DaoSingleton();
                    }
                }
            }
            return _instance;
        }

        public static List<string> Getall()
        {
            return _collection;
        }

        public static void AddOne(string str)
        {
            _collection.Add(str);
        }

        public static void Remove(int index)
        {
            _collection.Remove(_collection[index]);
        }
    }
}
