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
    }
}