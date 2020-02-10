using System;

namespace Lesson52
{
    class Program
    {
        static void Main(string[] args)
        {

            Shape triangle = new Triangle(new int[] { 3, 4, 5 });
            Console.WriteLine($"Triangle area = {triangle.CalcArea()}");
            Console.WriteLine($"Triangle perimeter = {triangle.CalcPerimeter()}");

            triangle.WriteSidesLength();
            Console.WriteLine("-----------");

            triangle.Resize(new int[] { 4, 4, 5 });
            Console.WriteLine($"Resized. Triangle area = {triangle.CalcArea()}");
            Console.WriteLine($"Resized. Triangle perimeter = {triangle.CalcPerimeter()}");

            triangle.WriteSidesLength();
            Console.WriteLine("-----------");

            Shape rec = new Rectangle(new int[] { 5, 6 });
            Console.WriteLine($"Rec area: {rec.CalcArea()}");
            Console.WriteLine($"Rec perimeter: {rec.CalcPerimeter()}");
            
            rec.WriteSidesLength();
            Console.WriteLine("-----------");

            rec.Resize(new int[] { 7, 7 });
            Console.WriteLine($"Resized. Rec area: {rec.CalcArea()}");
            Console.WriteLine($"Resized. Rec perimeter: {rec.CalcPerimeter()}");

            rec.WriteSidesLength();
            Console.WriteLine("-----------");

            Polygon sq = new Square(8);
            Console.WriteLine($"Square sq area = {sq.CalcArea()}");
            Console.WriteLine($"Square sq perimeter = {sq.CalcPerimeter()}");

            sq.WriteSidesLength();
            Console.WriteLine("-----------");

            sq.Resize(10);
            Console.WriteLine($"Resize. Square sq area = {sq.CalcArea()}");
            Console.WriteLine($"Resize. Square sq perimeter = {sq.CalcPerimeter()}");

            sq.WriteSidesLength();
            Console.WriteLine("-----------");

            Shape c = new Circumference(7);
            Console.WriteLine($"Circ. area = {c.CalcArea()}");
            Console.WriteLine($"Circ. length = {c.CalcPerimeter()}");

            c.WriteSidesLength();
            Console.WriteLine("-----------");

            c.Resize(9);
            Console.WriteLine($"Resize. Circ. area = {c.CalcArea()}");
            Console.WriteLine($"Resize. Circ. length = {c.CalcPerimeter()}");

            c.WriteSidesLength();
            Console.WriteLine("-----------");
        }
    }
}
