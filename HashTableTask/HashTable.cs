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

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
    }
}
