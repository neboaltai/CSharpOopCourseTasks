using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTableTask
{
    class HashTable<T> : ICollection<T>
    {
        private readonly List<T>[] lists;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        private int modCount;

        public HashTable() : this(10) { }

        public HashTable(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException($"Invalid capacity. Hash table capacity ({capacity}) must be > 0", nameof(capacity));
            }

            lists = new List<T>[capacity];
        }

        private int GetIndex(T item)
        {
            if (item is null)
            {
                return 0;
            }

            return Math.Abs(item.GetHashCode() % lists.Length);
        }

        public void Add(T item)
        {
            int index = GetIndex(item);

            if (lists[index] is null)
            {
                lists[index] = new List<T>(1);
            }

            lists[index].Add(item);

            Count++;

            modCount++;
        }

        public void Clear()
        {
            if (Count == 0)
            {
                return;
            }

            Array.Clear(lists, 0, lists.Length);

            Count = 0;

            modCount++;
        }

        public bool Contains(T item)
        {
            int index = GetIndex(item);

            return lists[index] is null ? false : lists[index].Contains(item);
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

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException($"The count of elements ({Count}) in the list is greater than the specified count of elements ({array.Length - arrayIndex}) in the array", nameof(array));
            }

            foreach (List<T> item in lists)
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
            int currentModCount = modCount;

            foreach (List<T> list in lists)
            {
                if (list != null)
                {
                    foreach (T e in list)
                    {
                        if (currentModCount != modCount)
                        {
                            throw new InvalidOperationException("The hash table has been modified");
                        }

                        yield return e;
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

            if (lists[index] != null && lists[index].Remove(item))
            {
                Count--;

                modCount++;

                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this)}]";
        }
    }
}
