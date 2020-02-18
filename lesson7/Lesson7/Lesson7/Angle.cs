using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson7
{
    public class Angle : IEnumerable, IComparable
    {
        int _deg = 0;
        int _min = 0;
        int _sec = 0;

        public int Degree 
        {
            get { return _deg; }
            set 
            {
                _deg = value > 360 ? value - 360 : value;
            }
        }
        public int Minutes 
        {
            get { return _min; }
            set 
            {  
                if(value >= 60)
                {
                    Degree += value / 60;
                }        
                _min = value % 60;      
            }
        }
        public int Seconds
        {
            get { return _sec; }
            set 
            { 
                if(value >= 60)
                {
                    Minutes += value / 60;
                }                
                _sec = value % 60;
            }
        }

        public Angle(int deg, int min, int sec)
        {
            if(deg < 0 || min < 0 || sec < 0)
            {
                Console.WriteLine("Invalid input.");
                Degree = Minutes = Seconds = 0;
                return;
            }
            Degree = deg;
            Minutes = min;
            Seconds = sec;
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
            return $"{_deg}:{_min}:{_sec}".GetHashCode();
        }

        public override string ToString()
        {
            return $"{_deg}°\t{_min}'\t{_sec}''";
        }

        public IEnumerator GetEnumerator()
        {
            return new AngleEnumerator(this);
        }

        //public IEnumerator GetEnumerator()
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        yield return this[i];
        //    }
        //}


        //compare angles, using such logic: if degrees are equal, we sort by minutes
        //if degrees and minutes are equal, then we watch to seconds and sort by them
        //angles are equal when ALL properties are equal to each other only
        public int CompareTo(object obj)
        {
            Angle a = obj as Angle;
            if(this._deg < a._deg)
            {
                return -1;
            }
            if(this._deg == a._deg && this._min < a._min)
            {
                return -1;
            }
            if(this._deg == a._deg && this._min == a._min && this._sec < a._sec)
            {
                return -1;
            }
            if(this._deg == a._deg && this._min == a._min && this._sec == a._sec)
            {
                return 0;
            }

            return 1;
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
            //var s = a1._sec + a2._sec;
            //var m = a1._min + a2._min + s / 60;
            //var d = a1._deg + a2._deg + m / 60;

            //s %= 60;
            //m %= 60;

            //return new Angle(d, m, s);
            return new Angle(a1.Degree + a2.Degree, a1.Minutes + a2.Minutes, a1.Seconds + a2.Seconds);
        }

        public static Angle operator -(Angle a1, Angle a2)
        {
            var s1 = ToSeconds(a1);
            var s2 = ToSeconds(a2);

            var dif = s1 - s2;
            if(dif >= 0)
            {
                return ToAngle(dif);
            }
            //make dif greater than zero
            dif *= -1;
            var ang = ToAngle(dif);
            //we should get something like: ang + X = 359°59'60'' = 360°
            return new Angle(359 - ang._deg, 59 - ang._min, 60 - ang._sec);
        }

        public static Angle operator *(Angle a, int n)
        {
            //convert angle to seconds
            var s = ToSeconds(a);
            return ToAngle(s * n);
        }

        public static Angle operator *(int n, Angle a)
        {
            //convert angle to seconds
            var s = ToSeconds(a);
            return ToAngle(s * n);
        }

        public static Angle operator /(Angle a, int n)
        {
            var s = ToSeconds(a);
            return ToAngle(s / n);
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

        public static int ToSeconds(Angle a)
        {
            return a._sec + a._min * 60 + a._deg * 3600;
        }

        private static Angle ToAngle(int s)
        {
            int deg = s / 3600;
            s %= 3600;
            int min = s / 60;
            int sec = s % 60;
            return new Angle(deg, min, sec);
        }

        private class AngleEnumerator : IEnumerator
        {
            private readonly Angle _angle;
            private int _index;

            public AngleEnumerator(Angle a)
            {
                _angle = a;
                _index = -1;
            }
            public object Current => _angle[_index];

            public bool MoveNext()
            {
                return ++_index < 3;
            }

            public void Reset()
            {
                _index = -1;
            }
        }
    }
}
