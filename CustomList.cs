using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SyncHotel
{
    /// <summary>
    /// CustomList is Manually created list which has the same functunality as the Feneric List
    /// </summary>
    /// <typeparam name="Type"></typeparam>
    public class CustomList<Type> : IEnumerable, IEnumerator
    {
        private int _count;
        private int _capacity;
        public int Count { get { return _count; } }
        public int Capacity { get { return _capacity; } }

        public object Current { get { return _array[position]; } }

        private Type[] _array;
        public Type this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }
        public CustomList()
        {
            _count = 0;
            _capacity = 5;
            _array = new Type[_capacity];
        }

        public CustomList(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new Type[size];
        }
        public void Add(Type value)
        {
            if (_count == _capacity)
            {
                GrowSize();
            }
            _array[_count] = value;
            _count++;
        }
        public void GrowSize()
        {
            _capacity *= 2;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp;
        }
        public void Remove(Type value)
        {
            int index = IndexOF(value);
            if (index >= 0)
            {
                RemoveAt(index);
            }
        }
        public void RemoveAt(int index)
        {
            for (int i = 0; i < _count - 1; i++)
            {
                if (index <= i)
                {
                    _array[i] = _array[i + 1];
                }
            }
            _count--;
        }
        public int IndexOF(Type value)
        {
            for (int i = 0; i < _count; i++)
            {
                if (IsEqual(value, _array[i]))
                {
                    return i;
                }
            }
            return -1;
        }
        public void Clear()
        {
            _count = 0;
            _capacity = 5;
            _array = new Type[_capacity];
        }
        public bool IsEqual(Type value, Type value1)
        {
            bool result = Comparer<Type>.Equals(value, value1);
            return result;
        }
        public static int BinarySearch(CustomList<Type> list, string search, string property, out Type element)
        {
            element = default;
            int low = 0, high = list.Count - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                object value = typeof(Type).GetProperty(property).GetValue(list[mid]);
                int result = value.ToString().CompareTo(search);
                if (result == 0)
                {
                    element = list[mid];
                    return mid;
                }
                else if (result > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return -1;
        }
        public bool MoveNext()
        {
            if (position < _count - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
        public int position;
        public IEnumerator GetEnumerator()
        {
            position = -1;
            return this;
        }
    }
}