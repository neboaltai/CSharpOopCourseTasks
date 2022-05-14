namespace TreeTask
{
    class TreeNode<T>
    {
        public T Data { get; }

        public TreeNode<T> Left { get; set; }

        public TreeNode<T> Right { get; set; }

        public TreeNode(T data)
        {
            Data = data;
        }
    }
}
