using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyVector
{
    class MyVector<T> : IEnumerable
    {
        //collection will increase by this size if there is no empty place
        private const int DefaultSize = 4;
        //this property returns the actual number of items
        public int Size { get; private set; }
        public int Capacity { get; private set; }
        private int _index;

        private T[] collection;

        public MyVector()
        {
            Capacity = DefaultSize;
            collection = new T[DefaultSize];
            _index = 0;
        }

        public MyVector(int size)
        {
            //prevent negative number input
            Capacity = size < 0 ? 0 : size;
            collection = new T[Capacity];
            _index = 0;
            Size = 0;
        }

        public void Add(T item)
        {
            if (_index >= Capacity)
            {
                T[] tmp = new T[Capacity + DefaultSize];
                int i = 0;
                while (i < _index)
                {
                    tmp[i] = collection[i];
                    i++;
                }
                tmp[i] = item;
                collection = tmp;
                Capacity = tmp.Length;
            } else
            {
                collection[_index] = item;
            }
            Size++;
            _index++;
        }

        public void InsertAt(int pos, T item)
        {
            if (pos < 0 || pos > Size)
            {
                throw new ArgumentOutOfRangeException($"Attempt to access unassigned memory area.");
            } else if (pos == Size)
            {
                Add(item);
            } else
            {
                int i = 0, j = 0;
                var tmp = new T[Size + DefaultSize];
                while (i < pos)
                {
                    tmp[j] = collection[i];
                    i++;
                    j++;
                }
                tmp[j++] = item;
                while (i < Size)
                {
                    tmp[j] = collection[i];
                    i++;
                    j++;
                }
                collection = tmp;
            }
            _index++;
            Size++;
        }

        public void RemoveAt(int pos)
        {
            if (pos < 0 || pos >= Size)
            {
                throw new ArgumentOutOfRangeException($"Attempt to access unassigned memory area.");
            }
            var tmp = new T[Size - 1];
            int i = 0, j = 0;
            while (i < pos)
            {
                tmp[j] = collection[i];
                i++;
                j++;
            }
            i++;
            while (i < Size)
            {
                tmp[j] = collection[i];
                i++;
                j++;
            }
            collection = tmp;
            Size--;
        }
        public T this[int index]
        {
            get { return collection[index]; }
            set { collection[index] = value; }
        }

        public void Swap(int left, int right)
        {
            if (left < 0 || left >= Size || right < 0 || right >= Size)
            {
                throw new ArgumentOutOfRangeException($"Attempt to access unassigned memory area.");
            }
            var tmp = collection[left];
            collection[left] = collection[right];
            collection[right] = tmp;
        }

        public IEnumerable<T> GetCollection()
        {
            return collection;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                if (collection[i] != null)
                {
                    yield return collection[i];
                }
            }
        }
    }
}
