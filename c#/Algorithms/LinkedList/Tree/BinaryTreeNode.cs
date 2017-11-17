namespace DataStructures
{
    class BinaryTreeNode<T>
    {
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public T Value { get; }

        public BinaryTreeNode(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            var left = "<" + (Left != null? $"{Left}" : "_") + ",";
            var right = "," + (Right!=null? $"{Right}" : "_") + ">";

            return $"{left}{Value}{right}";
        }
    }
}
