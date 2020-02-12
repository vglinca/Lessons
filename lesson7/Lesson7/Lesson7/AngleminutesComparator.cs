using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson7
{
    class AngleminutesComparator : IComparer
    {
        public int Compare(object x, object y)
        {
            Angle a1 = x as Angle;
            Angle a2 = y as Angle;

            return (a1.Minutes == a2.Minutes ? 0 : (a1.Minutes < a2.Minutes ? -1 : 1));
        }
    }
}
