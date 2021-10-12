using System.Collections.Generic;

namespace GeekBrains.Learn.TreeTraversal
{
    class Node
    {
        public int Value { get; set; }
        public int Lvl { get; set; }
        public ICollection<Node> Children { get; set; }
    }
}
