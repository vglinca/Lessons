using System;

namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            Angle a = new Angle(3, 36, 53);
            Angle b = new Angle(4, 27, 45);
            Angle m = new Angle(4, 27, 36);

            Angle c = a + b;
            Console.WriteLine($"<c({c[0]}°{c[1]}'{c[2]}'') = <a({a[0]}°{a[1]}'{a[2]}'') + <b({b[0]}°{b[1]}'{b[2]}'')");

            Console.WriteLine($"a == b ? {a == b}");
            Console.WriteLine($"a != b ? {a != b}");

            Console.WriteLine("----------------------");

            Console.WriteLine($"c[0] = {c[0]}\nc[1] = {c[1]}\nc[2] = {c[2]}");

            var s = new Angle(20, 65, 23);
            Console.WriteLine(s.ToString());

            Console.WriteLine("----------------------");

            var d = new Angle(34, 56, 7);
            var e = new Angle(54, 8, 9);
            var h = new Angle(54, 10, 9);
            var n = new Angle(54, 54, 54);

            //Angle[] angles = { n, e, b, m, a, d, h };
            //Console.WriteLine("\t\tWithout sort");
            //foreach (var angle in angles)
            //{
            //    Console.WriteLine(angle.ToString());
            //}

            //Console.WriteLine("----------------------");
            //Console.WriteLine("\t\tUsual sort");

            //Array.Sort(angles);
            //foreach (var angle in angles)
            //{
            //    Console.WriteLine(angle.ToString());
            //}

            //Console.WriteLine("----------------------");
            //Console.WriteLine("\t\tSort by minutes");
            //Array.Sort(angles, new AngleminutesComparator());
            //foreach (var angle in angles)
            //{
            //    Console.WriteLine(angle.ToString());
            //}

            //Console.WriteLine("----------------------");
            //Console.WriteLine("\t\tSort by seconds");
            //Array.Sort(angles, new AngleSecondsComparator());
            //foreach (var angle in angles)
            //{
            //    Console.WriteLine(angle.ToString());
            //}

            //Console.WriteLine("----------------------");
            //Console.WriteLine("\t\tSort by degrees");
            //Array.Sort(angles, new AngleDegreesComparator());
            //foreach (var angle in angles)
            //{
            //    Console.WriteLine(angle.ToString());
            //}
        }
    }
}
