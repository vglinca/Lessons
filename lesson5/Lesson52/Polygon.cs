using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson52
{
    abstract class Polygon : Shape
    {
        protected readonly int _sidesNumberToSpecify;
        protected double Perimeter {  get;  set; } = 0;
        protected int[] Sides { get; set; }
        public Polygon(int n) => _sidesNumberToSpecify = n;
        public override void WriteSidesLength()
        {
            for (int i = 0; i < _sidesNumberToSpecify; i++)
            {
                Console.WriteLine($"side {i + 1}: {Sides[i]}");
            }
        }
    }
}
