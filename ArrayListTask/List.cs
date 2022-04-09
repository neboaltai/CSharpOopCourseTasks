using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayListTask
{
    class List<T> : IList<T>
    {
        private T[] items;

        private int count;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public int Capacity
        {
            get
            {
                return items.Length;
            }
            set
            {
                if (value < Count)
                {
                    throw new InvalidOperationException($"Invalid value. The value {value} must not be less than the count of items ({Count})");
                }

                if (value > Count)
                {
                    T[] old = items;

                    items = new T[value];

                    Array.Copy(old, items, old.Length);
                }
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Parameter value {index} is invalid. The index must be between 0 and {Count - 1} inclusive");
                }

                return items[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Parameter value {index} is invalid. The index must be between 0 and {Count - 1} inclusive");
                }

                items[index] = value;
            }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public List() : this(10) { }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException($"Parameter value {capacity} is invalid. List capacity must not be negative", nameof(capacity));
            }

            items = new T[capacity];
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}
