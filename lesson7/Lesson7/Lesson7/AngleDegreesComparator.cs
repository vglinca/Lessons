using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson7
{
    public class AngleDegreesComparator : IComparer
    {
        public int Compare(object x, object y)
        {
            Angle a1 = x as Angle;
            Angle a2 = y as Angle;

            return (a1.Degree == a2.Degree ? 0 : (a1.Degree < a2.Degree ? -1 : 1));
        }
    }
}
