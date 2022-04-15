using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTableTask
{
    class HashTable<T> : ICollection<T>
    {
        private List<T>[] items;

        public int Count { get; private set; }

        public bool IsReadOnly => throw new NotImplementedException();

        private int modCount;

        public HashTable() : this(10) { }

        public HashTable(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException($"Parameter value {capacity} is invalid. Hash table capacity must be > 0", nameof(capacity));
            }

            items = new List<T>[capacity];
        }

        private int GetIndex(T item)
        {
            if (item is null)
            {
                return 0;
            }
            else
            {
                return Math.Abs(item.GetHashCode() % items.Length);
            }
        }

        public void Add(T item)
        {
            int index = GetIndex(item);

            if (items[index] is null)
            {
                items[index] = new List<T>(1);
            }

            items[index].Add(item);

            Count++;

            modCount++;
        }

        public void Clear()
        {
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = null;
            }

            Count = 0;

            modCount++;
        }

        public bool Contains(T item)
        {
            int index = GetIndex(item);

            if (items[index] != null)
            {
                return items[index].Contains(item);
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null");
            }

            if (arrayIndex < 0 || arrayIndex > array.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Parameter value {arrayIndex} is invalid. The index must be between 0 and {array.Length - 1} inclusive");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new InvalidOperationException("Destination array was not long enough. Check the destination index, length, and the array's lower bounds");
            }

            foreach (List<T> item in items)
            {
                if (item != null)
                {
                    item.CopyTo(array, arrayIndex);

                    arrayIndex += item.Count;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int count = modCount;

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    for (int j = 0; j < items[i].Count; j++)
                    {
                        if (count != modCount)
                        {
                            throw new InvalidOperationException("The hash table is invalid");
                        }

                        yield return items[i][j];
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Remove(T item)
        {
            int index = GetIndex(item);

            if (items[index] is null)
            {
                return false;
            }

            Count--;

            modCount++;

            return items[index].Remove(item);
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this)}]";
        }
    }
}
