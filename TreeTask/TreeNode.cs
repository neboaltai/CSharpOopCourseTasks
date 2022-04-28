namespace TreeTask
{
    class TreeNode<T>
    {
        public T Data { get; }

        public TreeNode<T> Left { get; set; }

        public TreeNode<T> Right { get; set; }

        public TreeNode(T data) : this(data, null, null) { }

        public TreeNode(T data, TreeNode<T> left, TreeNode<T> right)
        {
            Data = data;

            Left = left;
            Right = right;
        }
    }
}
