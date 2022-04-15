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

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
    }
}
