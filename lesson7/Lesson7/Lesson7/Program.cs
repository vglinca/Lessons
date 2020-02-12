using System;

namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            Angle a = new Angle(3, 36, 53);
            Angle b = new Angle(4, 27, 45);

            Angle c = a + b;
            Console.WriteLine(c.ToString());

            Console.WriteLine($"a == b ? {a == b}");
            Console.WriteLine($"a != b ? {a != b}");

            Console.WriteLine($"c[0] = {c[0]}\nc[1] = {c[1]}\nc[2] = {c[2]}");

        }
    }
}
