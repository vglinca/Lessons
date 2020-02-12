using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson7
{
    public class Angle : IEnumerable
    {
        int _deg = 0;
        int _min = 0;
        int _sec = 0;

        public Angle(int deg, int min, int sec)
        {
            if(min >= 60 || sec >= 60 || min <= 0 || sec <= 0)
            {
                Console.WriteLine($"Minutes either seconds must be greater than 0 and smaller than 60.");
                return;
            }
            _deg = deg;
            _min = min;
            _sec = sec;
        }

        public override bool Equals(object obj)
        {
            return obj is Angle angle &&
                   _deg == angle._deg &&
                   _min == angle._min &&
                   _sec == angle._sec;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_deg, _min, _sec);
        }

        public override string ToString()
        {
            return $"{_deg} {_min}' {_sec}''";
        }

        public IEnumerator GetEnumerator()
        {
            return new AngleEnumerator(this);
        }

        public static bool operator ==(Angle a1, Angle a2)
        {
            return a1._min == a2._min && a1._deg == a2._deg && a1._sec == a2._sec;
        }
        public static bool operator != (Angle a1, Angle a2)
        {
            return !(a1 == a2);
        }

        public static Angle operator +(Angle a1, Angle a2)
        {
            var s = a1._sec + a2._sec;
            var m = a1._min + a2._min + s / 60;
            var d = a1._deg + a2._deg + m / 60;

            s %= 60;
            m %= 60;

            return new Angle(d, m, s);
        }

        public int this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return _deg;
                    case 1:
                        return _min;
                    case 2:
                        return _sec;
                    default:
                        throw new IndexOutOfRangeException($"Trying to access to not assigned part of memory by indes {i}");
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        _deg = value;
                        break;
                    case 1:
                        _min = value;
                        break;
                    case 2:
                        _sec = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException($"Trying to access to not assigned part of memory by indes {i}");
                }
            }
        }
        
    }
}
