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

        private void IncreaseCapacity()
        {
            if (Capacity == 0)
            {
                items = new T[1];
            }
            else
            {
                T[] old = items;

                items = new T[old.Length * 2];

                Array.Copy(old, items, old.Length);
            }
        }

        public void Add(T item)
        {
            if (count == Capacity)
            {
                IncreaseCapacity();
            }

            items[count] = item;

            count++;
        }

        public void Clear()
        {
            for (int i = 0; i < count; i++)
            {
                items[i] = default(T);
            }

            count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (item is null)
                {
                    if (items[i] is null)
                    {
                        return true;
                    }

                    continue;
                }

                if (item.Equals(items[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null");
            }

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Parameter value {arrayIndex} is invalid. The index must be between 0 and {array.Length - 1} inclusive");
            }

            Array.Copy(items, 0, array, arrayIndex, Math.Min(array.Length - arrayIndex, count));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (item is null)
                {
                    if (items[i] is null)
                    {
                        return i;
                    }

                    continue;
                }

                if (item.Equals(items[i]))
                {
                    return i;
                }
            }

            return -1;
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
