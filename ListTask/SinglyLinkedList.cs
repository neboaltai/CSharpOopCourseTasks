using System;

namespace ListTask
{
    class SinglyLinkedList<T>
    {
        public SinglyLinkedListNode<T> Head { get; private set; }

        public int Count { get; private set; }

        public SinglyLinkedList() { }

        public SinglyLinkedList(SinglyLinkedListNode<T> head)
        {
            Head = head;

            for (SinglyLinkedListNode<T> node = head; node != null; node = node.Next)
            {
                Count++;
            }
        }

        public T GetFirstValue()
        {
            return Head.Data;
        }

        public T GetValue(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Parameter value {index} is invalid. The index must be between 0 and {Count - 1} inclusive");
            }

            SinglyLinkedListNode<T> node = Head;

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node.Data;
        }
    }
}