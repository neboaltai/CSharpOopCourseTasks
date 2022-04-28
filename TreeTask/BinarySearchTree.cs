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
    }
}