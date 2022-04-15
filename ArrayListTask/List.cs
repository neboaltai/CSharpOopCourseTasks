using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayListTask
{
    class List<T> : IList<T>
    {
        private T[] items;

        public int Count { get; private set; }

        private int modCount;

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
                CheckIndex(index, Count - 1);

                return items[index];
            }
            set
            {
                CheckIndex(index, Count - 1);

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

        private static void CheckIndex(int index, int maxIndex)
        {
            if (index < 0 || index > maxIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Parameter value {index} is invalid. The index must be between 0 and {maxIndex} inclusive");
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
            if (Count == Capacity)
            {
                IncreaseCapacity();
            }

            items[Count] = item;

            Count++;

            modCount++;
        }

        public void Clear()
        {
            Array.Clear(items, 0, Count);

            Count = 0;

            modCount++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
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

            CheckIndex(arrayIndex, array.Length - 1);

            Array.Copy(items, 0, array, arrayIndex, Math.Min(array.Length - arrayIndex, Count));
        }

        public IEnumerator<T> GetEnumerator()
        {
            int count = modCount;

            for (int i = 0; i < Count; i++)
            {
                if (count != modCount)
                {
                    throw new InvalidOperationException("The list is invalid");
                }

                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
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
            CheckIndex(index, Count);

            if (index == Count)
            {
                Add(item);

                return;
            }

            if (Count == Capacity)
            {
                IncreaseCapacity();
            }

            T[] old = items;

            Array.Copy(old, index, items, index + 1, Count - index);

            items[index] = item;

            Count++;

            modCount++;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Count; i++)
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
            CheckIndex(index, Count - 1);

            if (index < Count - 1)
            {
                Array.Copy(items, index + 1, items, index, Count - index - 1);
            }

            items[Count - 1] = default(T);

            Count--;

            modCount++;
        }

        public void TrimExcess()
        {
            if (Capacity > Count)
            {
                T[] result = new T[Count];

                Array.Copy(items, result, Count);

                items = result;
            }
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this)}]";
        }
    }
}
