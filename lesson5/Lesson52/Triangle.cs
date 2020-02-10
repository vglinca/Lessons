using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson52
{
    class Triangle : Polygon
    {
        public Triangle(int[] sides) : base(3)
        {
            if(sides.Length != 3)
            {
                Console.WriteLine("Triangle has 3 sides.");
                return;
            }
            Sides = new int[_sidesNumberToSpecify];
            Sides = sides;
        }
        public override double CalcArea()
        {
            if(_sidesNumberToSpecify == 3)
            {
                double halfP = 0;
                CalcPerimeter();

                halfP = Perimeter / 2;
                double a = Math.Sqrt(halfP * (halfP - Sides[0]) * (halfP - Sides[1]) * (halfP - Sides[2]));
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
            if (_sidesNumberToSpecify == 3)
            {
                Perimeter = 0;
                for (int i = 0; i < _sidesNumberToSpecify; i++)
                {
                    Perimeter += Sides[i];
                }
                return Perimeter;
            } 
            else {
                Console.WriteLine("Could not calculate perimeter.");
                return -1;
            }
        }

        public override void Resize(int[] newSides)
        {
            if(newSides.Length == 3)
            {
                Sides = newSides;
            } 
            else
            {
                Console.WriteLine("Could not resize triangle.");
            }
        }
    }
}
