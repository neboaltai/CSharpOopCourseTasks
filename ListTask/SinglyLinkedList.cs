using System;
using System.Text;

namespace ListTask
{
    public class SinglyLinkedList<T>
    {
        private ListNode<T> head;

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                CheckIndex(index, Count - 1);

                return GetNode(index).Data;
            }
            set
            {
                CheckIndex(index, Count - 1);

                GetNode(index).Data = value;
            }
        }

        public SinglyLinkedList() { }

        public SinglyLinkedList(T data)
        {
            head = new ListNode<T>(data);

            Count++;
        }

        private static void CheckIndex(int index, int maxIndex)
        {
            if (index < 0 || index > maxIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Invalid index. The index ({index}) must be between 0 and {maxIndex} inclusive");
            }
        }

        private ListNode<T> GetNode(int index)
        {
            ListNode<T> node = head;

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node;
        }

        public T GetFirst()
        {
            if (head is null)
            {
                throw new InvalidOperationException("The list is empty");
            }

            return head.Data;
        }

        public T RemoveAt(int index)
        {
            CheckIndex(index, Count - 1);

            if (index == 0)
            {
                return RemoveFirst();
            }

            ListNode<T> previousNode = GetNode(index - 1);

            ListNode<T> currentNode = previousNode.Next;

            T removedData = currentNode.Data;

            previousNode.Next = currentNode.Next;

            Count--;

            return removedData;
        }

        public void AddFirst(T data)
        {
            head = new ListNode<T>(data, head);

            Count++;
        }

        public void Add(int index, T data)
        {
            CheckIndex(index, Count);

            if (index == 0)
            {
                AddFirst(data);

                return;
            }

            ListNode<T> previousNode = GetNode(index - 1);

            previousNode.Next = new ListNode<T>(data, previousNode.Next);

            Count++;
        }

        public bool Remove(T data)
        {
            for (ListNode<T> currentNode = head, previousNode = null; currentNode != null; previousNode = currentNode, currentNode = currentNode.Next)
            {
                if (Equals(data, currentNode.Data))
                {
                    if (previousNode == null)
                    {
                        head = currentNode.Next;
                    }
                    else
                    {
                        previousNode.Next = currentNode.Next;
                    }

                    Count--;

                    return true;
                }
            }

            return false;
        }

        public T RemoveFirst()
        {
            if (head is null)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T removedData = head.Data;

            head = head.Next;

            Count--;

            return removedData;
        }

        public void Reverse()
        {
            ListNode<T> nextNode = head;

            for (ListNode<T> currentNode = head, previousNode = null; currentNode != null; previousNode = currentNode, currentNode = nextNode)
            {
                if (currentNode.Next is null)
                {
                    head = nextNode;
                }

                nextNode = currentNode.Next;

                currentNode.Next = previousNode;
            }
        }

        public SinglyLinkedList<T> Copy()
        {
            if (head is null)
            {
                return new SinglyLinkedList<T>();
            }

            SinglyLinkedList<T> result = new SinglyLinkedList<T>(head.Data);

            ListNode<T> resultNode = result.head;

            for (ListNode<T> node = head.Next; node != null; node = node.Next)
            {
                resultNode.Next = new ListNode<T>(node.Data);

                resultNode = resultNode.Next;
            }

            result.Count = Count;

            return result;
        }

        public override string ToString()
        {
            if (head is null)
            {
                return "[]";
            }

            StringBuilder result = new StringBuilder("[");

            for (ListNode<T> node = head; node != null; node = node.Next)
            {
                result.Append(node.Data).Append(", ");
            }

            result.Remove(result.Length - 2, 2);

            result.Append("]");

            return result.ToString();
        }
    }
}