using System;
using System.Collections.Generic;

namespace TreeTask
{
    public class BinarySearchTree<T>
    {
        private readonly IComparer<T> comparer;

        private TreeNode<T> root;

        public int Count { get; private set; }

        public BinarySearchTree() { }

        public BinarySearchTree(T data) : this(data, null) { }

        public BinarySearchTree(T data, IComparer<T> comparer)
        {
            root = new TreeNode<T>(data);

            this.comparer = comparer;
        }

        private void CheckDataComparable()
        {
            if (comparer is null && root.Data as IComparable<T> is null)
            {
                throw new InvalidOperationException("Data cannot be compared");
            }
        }

        private int GetSign(T data1, T data2)
        {
            return comparer != null ? comparer.Compare(data1, data2) : (data1 as IComparable<T>).CompareTo(data2);
        }

        public void Add(T data)
        {
            if (root is null)
            {
                root = new TreeNode<T>(data);

                Count++;

                return;
            }

            CheckDataComparable();

            TreeNode<T> currentNode = root;

            while (true)
            {
                if (GetSign(currentNode.Data, data) > 0)
                {
                    if (currentNode.Left is null)
                    {
                        currentNode.Left = new TreeNode<T>(data);

                        Count++;

                        return;
                    }

                    currentNode = currentNode.Left;

                    continue;
                }

                if (currentNode.Right is null)
                {
                    currentNode.Right = new TreeNode<T>(data);

                    Count++;

                    return;
                }

                currentNode = currentNode.Right;
            }
        }
    }
}