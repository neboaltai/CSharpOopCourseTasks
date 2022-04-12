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
                CheckOutOfBounds(index, 0, Count - 1);

                return IterateUntil(index).Data;
            }
            set
            {
                CheckOutOfBounds(index, 0, Count - 1);

                IterateUntil(index).Data = value;
            }
        }

        public SinglyLinkedList() { }

        public SinglyLinkedList(T data)
        {
            head = new ListNode<T>(data);

            for (ListNode<T> node = head; node != null; node = node.Next)
            {
                Count++;
            }
        }

        private void CheckOutOfBounds(int index, int start, int end)
        {
            if (index < start || index > end)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Parameter value {index} is invalid. The index must be between {start} and {end} inclusive");
            }
        }

        private ListNode<T> IterateUntil(int index)
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
            CheckOutOfBounds(index, 0, Count - 1);

            if (index == 0)
            {
                return RemoveFirst();
            }

            ListNode<T> previousNode = IterateUntil(index - 1);

            ListNode<T> currentNode = previousNode.Next;

            T removedData = currentNode.Data;

            previousNode.Next = currentNode.Next;

            Count--;

            return removedData;
        }

        public void AddFirst(T data)
        {
            ListNode<T> node = new ListNode<T>(data, head);

            head = node;

            Count++;
        }

        public void Add(int index, T data)
        {
            CheckOutOfBounds(index, 0, Count);

            if (index == 0)
            {
                AddFirst(data);

                return;
            }

            ListNode<T> previousNode = IterateUntil(index - 1);

            ListNode<T> addedNode = new ListNode<T>(data, previousNode.Next);

            previousNode.Next = addedNode;

            Count++;
        }

        public bool Remove(T data)
        {
            for (ListNode<T> currentNode = head, previousNode = null; currentNode != null; previousNode = currentNode, currentNode = currentNode.Next)
            {
                if (data.Equals(currentNode.Data))
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

            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("[");

            for (ListNode<T> node = head; node != null; node = node.Next)
            {
                result.Append(node.Data).Append(", ");
            }

            if (head != null)
            {
                result.Remove(result.Length - 2, 2);
            }

            result.Append("]");

            return result.ToString();
        }
    }
}