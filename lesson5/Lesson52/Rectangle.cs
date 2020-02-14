using System;

namespace Lesson52
{
    class Rectangle : Polygon
    {
        public Rectangle(int[] sides) : base(2)
        {
            if (sides.Length != 2)
            {
                Console.WriteLine("Must specify 2 sides -height and width.");
                return;
            }
            Sides = new int[_sidesNumberToSpecify];
            Sides = sides;
        }
        public override double CalcArea()
        {
            if (_sidesNumberToSpecify == 2)
            {
                CalcPerimeter();

                double a = Sides[0] * Sides[1];
                return a;
            } 
            else
            {
                Console.WriteLine("Could not calculate area.");
                return -1;
            }
        }

        public override double CalcPerimeter()
        {
            if(_sidesNumberToSpecify == 2)
            {
                Perimeter = Sides[0] + Sides[1];

                return Perimeter;
            } 
            else
            {
                Console.WriteLine("Could not calculate perimeter.");
                return -1;
            }
        }

        public override void Resize(int[] newSides)
        {
            if (newSides.Length == 2)
            {
                Sides = newSides;
            } 
            else
            {
                Console.WriteLine("Could not resize rectangle.");
            }
        }
    }
}
