namespace ListTask
{
    class ListNode<T>
    {
        public T Data { get; set; }

        public ListNode<T> Next { get; set; }

        public ListNode(T data)
        {
            Data = data;
        }

        public ListNode(T data, ListNode<T> next)
        {
            Data = data;
            Next = next;
        }
    }
}
