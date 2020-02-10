using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson52
{
    class Square : Polygon
    {
        public int Test { get; set; }
        public Square(int side) : base(1)
        {
            if(_sidesNumberToSpecify != 1)
            {
                Console.WriteLine("Must specify 1 side.");
                Console.WriteLine($"CTOR: {_sidesNumberToSpecify}");
                return;
            }
            
            Sides = new int[_sidesNumberToSpecify];
            Sides[0] = side;
        }
        public override double CalcArea()
        {
            if(_sidesNumberToSpecify == 1)
            {
                return Sides[0] * Sides[0];
            } 
            else
            {
                Console.WriteLine("Could not calculate area.");
                return -1;
            }
        }

        public override double CalcPerimeter()
        {
            if (_sidesNumberToSpecify == 1)
            {
                return Sides[0] * 4;
            } 
            else
            {
                Console.WriteLine("Could not calculate perimeter.");
                return -1;
            }
        }

        public override void Resize(int newSide)
        {
            Sides[0] = newSide;
        }
    }
}
