using System;

namespace Lesson52
{
    abstract class Shape
    {
        public abstract double CalcArea();
        public abstract double CalcPerimeter();
        public virtual void Resize(int[] newSides) { }
        public virtual void Resize(int newSide) { }
        public abstract void WriteSidesLength();
    }
}
