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

        public BinarySearchTree(IComparer<T> comparer) : this(default, comparer) { }

        public BinarySearchTree(T data, IComparer<T> comparer)
        {
            root = new TreeNode<T>(data);

            this.comparer = comparer;
        }

        private int Compare(T data1, T data2)
        {
            if (data1 is null)
            {
                return data2 is null ? 0 : -1;
            }

            if (comparer != null)
            {
                return comparer.Compare(data1, data2);
            }

            IComparable<T> comparableData = data1 as IComparable<T>;

            if (comparableData is null)
            {
                throw new InvalidOperationException("Data cannot be compared");
            }

            return comparableData.CompareTo(data2);
        }

        public void Add(T data)
        {
            if (root is null)
            {
                root = new TreeNode<T>(data);

                Count++;

                return;
            }

            TreeNode<T> currentNode = root;

            while (true)
            {
                if (Compare(data, currentNode.Data) < 0)
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

            TreeNode<T> currentNode = root;

            for (int sign; ;)
            {
                sign = Compare(data, currentNode.Data);

                if (sign == 0)
                {
                    return true;
                }

                if (sign < 0)
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

            TreeNode<T> nodeToRemove = root;
            TreeNode<T> nodeToRemoveParent = null;

            for (int sign; ;)
            {
                sign = Compare(data, nodeToRemove.Data);

                if (sign < 0)
                {
                    if (nodeToRemove.Left is null)
                    {
                        return false;
                    }

                    nodeToRemoveParent = nodeToRemove;
                    nodeToRemove = nodeToRemove.Left;

                    continue;
                }

                if (sign > 0)
                {
                    if (nodeToRemove.Right is null)
                    {
                        return false;
                    }

                    nodeToRemoveParent = nodeToRemove;
                    nodeToRemove = nodeToRemove.Right;

                    continue;
                }

                break;
            }

            if (nodeToRemove.Left is null)
            {
                if (nodeToRemove == root)
                {
                    root = nodeToRemove.Right;
                }
                else
                {
                    if (nodeToRemoveParent.Left == nodeToRemove)
                    {
                        nodeToRemoveParent.Left = nodeToRemove.Right;
                    }
                    else
                    {
                        nodeToRemoveParent.Right = nodeToRemove.Right;
                    }
                }

                Count--;

                return true;
            }

            if (nodeToRemove.Right is null)
            {
                if (nodeToRemove == root)
                {
                    root = nodeToRemove.Left;
                }
                else
                {
                    if (nodeToRemoveParent.Left == nodeToRemove)
                    {
                        nodeToRemoveParent.Left = nodeToRemove.Left;
                    }
                    else
                    {
                        nodeToRemoveParent.Right = nodeToRemove.Left;
                    }
                }

                Count--;

                return true;
            }

            TreeNode<T> minLeftNode = nodeToRemove.Right;
            TreeNode<T> minLeftNodeParent = null;

            while (minLeftNode.Left != null)
            {
                minLeftNodeParent = minLeftNode;
                minLeftNode = minLeftNode.Left;
            }

            if (minLeftNode != nodeToRemove.Right)
            {
                minLeftNodeParent.Left = minLeftNode.Right;

                minLeftNode.Right = nodeToRemove.Right;
            }

            minLeftNode.Left = nodeToRemove.Left;

            if (nodeToRemove == root)
            {
                root = minLeftNode;
            }
            else
            {
                if (nodeToRemoveParent.Left == nodeToRemove)
                {
                    nodeToRemoveParent.Left = minLeftNode;
                }
                else
                {
                    nodeToRemoveParent.Right = minLeftNode;
                }
            }

            Count--;

            return true;
        }

        public void BypassInBreadth(Action<T> action)
        {
            if (root is null)
            {
                return;
            }

            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>(Count / 2 + 1);

            queue.Enqueue(root);

            for (TreeNode<T> node; queue.Count != 0;)
            {
                node = queue.Dequeue();

                action(node.Data);

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }

        public void BypassInDepthWithCycle(Action<T> action)
        {
            if (root is null)
            {
                return;
            }

            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

            stack.Push(root);

            for (TreeNode<T> node; stack.Count != 0;)
            {
                node = stack.Pop();

                action(node.Data);

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }
        }

        public void BypassInDepthWithRecursion(Action<T> action)
        {
            if (root is null)
            {
                return;
            }

            BypassInDepthWithRecursion(root, action);
        }

        private static void BypassInDepthWithRecursion(TreeNode<T> node, Action<T> action)
        {
            action(node.Data);

            if (node.Left != null)
            {
                BypassInDepthWithRecursion(node.Left, action);
            }

            if (node.Right != null)
            {
                BypassInDepthWithRecursion(node.Right, action);
            }
        }
    }
}