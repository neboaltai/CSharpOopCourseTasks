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

                if (value >= Count)
                {
                    Array.Resize(ref items, value);
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

                modCount++;
            }
        }

        public bool IsReadOnly => false;

        public List() : this(10) { }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException($"Invalid capacity. List capacity ({capacity}) must not be negative", nameof(capacity));
            }

            items = new T[capacity];
        }

        private static void CheckIndex(int index, int maxIndex)
        {
            if (index < 0 || index > maxIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Invalid index. The index ({index}) must be between 0 and {maxIndex} inclusive");
            }
        }

        private void IncreaseCapacity()
        {
            if (Capacity == 0)
            {
                items = new T[1];

                return;
            }

            Capacity = items.Length * 2;
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
            if (Count == 0)
            {
                return;
            }

            Array.Clear(items, 0, Count);

            Count = 0;

            modCount++;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) == -1 ? false : true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null");
            }

            CheckIndex(arrayIndex, array.Length - 1);

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException($"The count of elements ({Count}) in the list is greater than the specified count of elements ({array.Length - arrayIndex}) in the array", nameof(array));
            }

            Array.Copy(items, 0, array, arrayIndex, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentModCount = modCount;

            foreach (T e in items)
            {
                if (currentModCount != modCount)
                {
                    throw new InvalidOperationException("The list has been modified");
                }

                yield return e;
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
                if (Equals(item, items[i]))
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

            Array.Copy(items, index, items, index + 1, Count - index);

            items[index] = item;

            Count++;

            modCount++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index, Count - 1);

            if (index < Count - 1)
            {
                Array.Copy(items, index + 1, items, index, Count - index - 1);
            }

            items[Count - 1] = default;

            Count--;

            modCount++;
        }

        public void TrimExcess()
        {
            if (Capacity > Count * 1.1)
            {
                Capacity = Count;
            }
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this)}]";
        }
    }
}
