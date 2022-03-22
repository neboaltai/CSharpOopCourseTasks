namespace ListTask
{
    class SinglyLinkedListNode<T>
    {
        public T Data { get; set; }

        public SinglyLinkedListNode<T> Next { get; set; }

        public SinglyLinkedListNode(T data)
        {
            Data = data;
        }

        public SinglyLinkedListNode(T data, SinglyLinkedListNode<T> next)
        {
            Data = data;
            Next = next;
        }
    }
}
