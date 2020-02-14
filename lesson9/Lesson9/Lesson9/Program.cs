using System;

namespace MyVector
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = new MyVector<int>() { 5, 8, 3, 6 };
            v.Add(9);
            v.Add(1);
            v.Add(2);
            v.Add(11);
            v.Add(21);
            v.Add(0);

            foreach (var item in v)
            {
                Console.WriteLine(item);
            }
        }
    }
}
