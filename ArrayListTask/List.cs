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
                if (value < count)
                {
                    throw new InvalidOperationException($"Invalid value. The value {value} must not be less than the count of items ({count})");
                }

                if (value > count)
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
                CheckOutOfBounds(index, 0, count - 1);

                return items[index];
            }
            set
            {
                CheckOutOfBounds(index, 0, count - 1);

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

        private void CheckOutOfBounds(int index, int start, int end)
        {
            if (index < start || index > end)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Parameter value {index} is invalid. The index must be between 0 and {end} inclusive");
            }
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

            CheckOutOfBounds(arrayIndex, 0, array.Length - 1);

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
            CheckOutOfBounds(index, 0, count);

            if (index == count)
            {
                Add(item);

                return;
            }

            if (count == Capacity)
            {
                IncreaseCapacity();
            }

            T[] old = items;

            Array.Copy(old, index, items, index + 1, count - index);

            items[index] = item;

            count++;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (item is null)
                {
                    if (items[i] is null)
                    {
                        RemoveAt(i);

                        return true;
                    }

                    continue;
                }

                if (item.Equals(items[i]))
                {
                    RemoveAt(i);

                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            CheckOutOfBounds(index, 0, count - 1);

            if (index < count - 1)
            {
                Array.Copy(items, index + 1, items, index, count - index - 1);
            }

            items[count - 1] = default(T);

            count--;
        }

        public void TrimExcess()
        {
            if (Capacity > count)
            {
                T[] result = new T[count];

                Array.Copy(items, result, count);

                items = result;
            }
        }
    }
}
