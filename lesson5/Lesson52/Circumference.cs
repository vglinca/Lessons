using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson52
{
    class Circumference : Shape
    {
        const double pi = Math.PI;
        int _radius;

        public Circumference(int r) => _radius = r;
        public override double CalcArea()
        {
            return pi * _radius * _radius;
        }

        public override double CalcPerimeter()
        {
            return 2 * pi * _radius;
        }

        public override void Resize(int r)
        {
            _radius = r;
        }

        public override void WriteSidesLength()
        {
            Console.WriteLine($"R = {_radius}");
        }
    }
}
