using System;
using System.Collections;
using System.Collections.Generic;
using Module3HW1.Comparer;

namespace Module3HW1.Collection
{
    public class CustomList<T> : IEnumerable<T>
    {
        private const int _defaultCapacity = 4;
        private T[] _data;
        private int _size = 0;
        private int _capacity;

        public CustomList()
        {
            _capacity = _defaultCapacity;
            _data = new T[_capacity];
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        public int Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public T this[int index]
        {
            get
            {
                IndexOutOfRange(index);

                return _data[index];
            }
            set
            {
                IndexOutOfRange(index);

                _data[index] = value;
            }
        }

        public void ResizeAddMethod()
        {
            if (_size == _capacity)
            {
                var resized = new T[_capacity * 2];
                for (var i = 0; i < _capacity; i++)
                {
                    resized[i] = _data[i];
                }

                _data = resized;
                _capacity = _capacity * 2;
            }
        }

        public void ResizeDelMethod()
        {
            if (_size < _capacity / 2)
            {
                var newcapacity = _capacity / 2;
                var temp = new T[newcapacity];
                Array.Copy(_data, temp, newcapacity);
                _data = new T[newcapacity];
                Array.Copy(temp, _data, newcapacity);
                _capacity = newcapacity;
            }
        }

        public void Add(T newElement)
        {
            ResizeAddMethod();
            _data[_size++] = newElement;
        }

        public void AddRange(IEnumerable<T> range)
        {
            foreach (var item in range)
            {
                ResizeAddMethod();
                Add(item);
            }
        }

        public void InsertAt(T newElement, int index)
        {
            IndexOutOfRange(index);
            ResizeAddMethod();

            for (var i = _size; i > index; i--)
            {
                _data[i] = _data[i - 1];
            }

            _data[index] = newElement;
            _size++;
        }

        public void RemoveAt(int index)
        {
            IndexOutOfRange(index);
            for (var i = index + 1; i < _size - 1; i++)
            {
                _data[i] = _data[i + 1];
            }

            _data[_size - 1] = default(T);
            _size--;
            ResizeDelMethod();
        }

        public bool Remove(T item)
        {
            for (var i = 0; i < _capacity; i++)
            {
                if (_data[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public void Sort()
        {
            Array.Sort(_data, new ListComparer<T>());
        }

        public void Clear()
        {
            _data = new T[_capacity];
            _size = 0;
        }

        public IEnumerator GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (var i = 0; i < _size; i++)
            {
                yield return _data[i];
            }
        }

        private void IndexOutOfRange(int index)
        {
            if (index > _size - 1 || index < 0)
            {
                throw new ArgumentOutOfRangeException($"The current size of the array is {_size}");
            }
        }
    }
}
