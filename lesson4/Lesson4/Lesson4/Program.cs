using System;

namespace RefVal {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            int a = 25; //value type
            string str = "random string"; //reference type

            Console.WriteLine($"Main()\na = {a} | str = {str}\n---------------");

            Change(str, a);

            Console.WriteLine($"Main()\na = {a} | str = {str}\n---------------");

            Change(ref str, ref a);

            Console.WriteLine($"Main()\na = {a} | str = {str}\n---------------");

            CreateCircle(out Circle circle);
            Console.WriteLine($"Circle with radius = {circle.r} " +
                $"and with coordinates: [{circle.x}, {circle.y}]\n---------------");

            //boxing & unboxing
            var p = new Person();
            p.id = 24; p.name = "Andrey";

            var p1 = new Person();
            p1.id = "shjdfgh45sagdg"; p1.name = "Ivan";

            object obj = "abcde";
            try {
                int x = (int)obj;
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        static void Change(string str, int a) {
            str = "abcde";
            a++;
            Console.WriteLine($"Change(string str, int a) \na = {a} | str = {str}\n---------------");
        }

        static void Change(ref string str, ref int a) {
            str = "abcdefg";
            a++;
            Console.WriteLine($"Change(ref string str, ref int a) \na = {a} | str = {str}\n---------------");
        }

        static void CreateCircle(out Circle c) {
            Console.WriteLine("CreateCircle(out Circle c)\n---------------");
            c.r = 10;
            c.x = 0;
            c.y = 21;
        }

        struct Circle {
            public int r;
            public int x;
            public int y;
        }
    }

    class Person {
        public object id;
        public string name;
    }
}
