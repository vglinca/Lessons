using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson7
{
    public class AngleEnumerator : IEnumerator
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
            _index++;
            return _index < 3;
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}
