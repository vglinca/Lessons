using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson7
{
    class AngleSecondsComparator : IComparer
    {
        public int Compare(object x, object y)
        {
            Angle a1 = x as Angle;
            Angle a2 = y as Angle;

            return (a1.Seconds == a2.Seconds ? 0 : (a1.Seconds < a2.Seconds ? -1 : 1));
        }
    }
}
