namespace GeekBrains.Learn.BinarySearchTree
{
    class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
