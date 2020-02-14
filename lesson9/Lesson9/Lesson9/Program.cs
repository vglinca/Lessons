using System;

namespace MyVector
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = new MyVector<string>(3) { "hello", "world", "here" };
            v.Add("ab");
            v.Add("dfty");
            v.Add("abw");
            v.Add("qqq");
            v.Add("lpo");
            v.Add("df");
            v.Add("zzz");
            v.Add("rfr");
            v.Add("kkk");

            foreach (var item in v)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------------------------------------------------");
            //v.InsertAt(6, "DDDDDDDD");
            Console.WriteLine(v.Size);

            v.RemoveAt(7);

            v.Swap(0, 1);
            for (int i = 0; i < v.Size; i++)
            {
                Console.WriteLine(v[i]);
            }


            var v1 = new MyVector<int>() { 2, 3, 4 };
            Console.WriteLine(v1.Size + "--------");
            foreach (var item in v1)
            {
                Console.WriteLine(item);
            }
        }
    }
}
