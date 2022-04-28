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

        public bool Contains(T data)
        {
            if (root is null)
            {
                return false;
            }

            CheckDataComparable();

            TreeNode<T> currentNode = root;

            int sign;

            while (true)
            {
                sign = GetSign(currentNode.Data, data);

                if (sign == 0)
                {
                    return true;
                }

                if (sign > 0)
                {
                    if (currentNode.Left is null)
                    {
                        return false;
                    }

                    currentNode = currentNode.Left;

                    continue;
                }

                if (currentNode.Right is null)
                {
                    return false;
                }

                currentNode = currentNode.Right;
            }
        }

        public bool Remove(T data)
        {
            if (root is null)
            {
                return false;
            }

            CheckDataComparable();

            TreeNode<T> nodeToDelete = root;
            TreeNode<T> nodeToDeleteParent = null;

            int sign;

            while (true)
            {
                sign = GetSign(nodeToDelete.Data, data);

                if (sign > 0)
                {
                    if (nodeToDelete.Left is null)
                    {
                        return false;
                    }

                    nodeToDeleteParent = nodeToDelete;
                    nodeToDelete = nodeToDelete.Left;

                    continue;
                }

                if (sign < 0)
                {
                    if (nodeToDelete.Right is null)
                    {
                        return false;
                    }

                    nodeToDeleteParent = nodeToDelete;
                    nodeToDelete = nodeToDelete.Right;

                    continue;
                }

                break;
            }

            if (nodeToDelete.Left is null)
            {
                if (nodeToDelete == root)
                {
                    root = nodeToDelete.Right;
                }
                else
                {
                    if (nodeToDeleteParent.Left == nodeToDelete)
                    {
                        nodeToDeleteParent.Left = nodeToDelete.Right;
                    }
                    else
                    {
                        nodeToDeleteParent.Right = nodeToDelete.Right;
                    }
                }

                Count--;

                return true;
            }

            if (nodeToDelete.Right is null)
            {
                if (nodeToDelete == root)
                {
                    root = nodeToDelete.Left;
                }
                else
                {
                    if (nodeToDeleteParent.Left == nodeToDelete)
                    {
                        nodeToDeleteParent.Left = nodeToDelete.Left;
                    }
                    else
                    {
                        nodeToDeleteParent.Right = nodeToDelete.Left;
                    }
                }

                Count--;

                return true;
            }

            TreeNode<T> minLeftNode = nodeToDelete.Right;
            TreeNode<T> minLeftNodeParent = null;

            while (minLeftNode.Left != null)
            {
                minLeftNodeParent = minLeftNode;
                minLeftNode = minLeftNode.Left;
            }

            if (minLeftNode != nodeToDelete.Right)
            {
                minLeftNodeParent.Left = minLeftNode.Right;

                minLeftNode.Right = nodeToDelete.Right;
            }

            minLeftNode.Left = nodeToDelete.Left;

            if (nodeToDelete == root)
            {
                root = minLeftNode;
            }
            else
            {
                if (nodeToDeleteParent.Left == nodeToDelete)
                {
                    nodeToDeleteParent.Left = minLeftNode;
                }
                else
                {
                    nodeToDeleteParent.Right = minLeftNode;
                }
            }

            Count--;

            return true;
        }

        public void BypassInBreadth()
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>(Count / 2 + 1);

            TreeNode<T> node = root;

            queue.Enqueue(node);

            while (queue.Count != 0)
            {
                node = queue.Dequeue();

                if (node is null)
                {
                    continue;
                }

                Console.WriteLine(node.Data);

                queue.Enqueue(node.Left);

                queue.Enqueue(node.Right);
            }
        }

        public void BypassInDepthWithCycle()
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

            TreeNode<T> node = root;

            stack.Push(node);

            while (stack.Count != 0)
            {
                node = stack.Pop();

                if (node is null)
                {
                    continue;
                }

                Console.WriteLine(node.Data);

                stack.Push(node.Right);

                stack.Push(node.Left);
            }
        }
    }
}