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
            set { _deg = value; }
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
            //if(min >= 60 || sec >= 60 || min <= 0 || sec <= 0)
            //{
            //    Console.WriteLine($"Minutes either seconds must be greater than 0 and smaller than 60.");
            //    return;
            //}
            //_deg = deg;
            //_min = min;
            //_sec = sec;
            if(deg < 0 || min < 0 || sec < 0)
            {
                throw new Exception("Angle cannot have negative parameters.");
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
            //return HashCode.Combine(_deg, _min, _sec);
            return $"{_deg} : {_min} : {_sec}".GetHashCode();
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
