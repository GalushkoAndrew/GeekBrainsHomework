using System;

namespace GeekBrains.Learn.BinarySearchTree
{
    class Test
    {
        public void Start()
        {
            Node head = new Node()
            {
                Data = 100,
                Left = new Node()
                {
                    Data = 90,
                    Left = new Node()
                    {
                        Data = 70,
                        Left = new Node()
                        {
                            Data = 20
                        },
                        Right = new Node()
                        {
                            Data = 72
                        }
                    },
                    Right = new Node()
                    {
                        Data = 93,
                        Right = new Node()
                        {
                            Data = 95
                        }
                    }
                },
                Right = new Node()
                {
                    Data = 160,
                    Left = new Node()
                    {
                        Data = 120,
                        Left = new Node()
                        {
                            Data = 110
                        },
                        Right = new Node()
                        {
                            Data = 153,
                            Left = new Node()
                            {
                                Data = 131
                            }
                        }
                    },
                    Right = new Node()
                    {
                        Data = 193,
                        Right = new Node()
                        {
                            Data = 1095
                        }
                    }
                },
            };

            DrawTree(head);
        }

        public void DrawTree(Node head, string indent = "", string mark = "H")
        {
            if (head != null)
            {
                string newIndent = indent + "  ";
                Console.WriteLine("{0}({2}){1}", indent, head, mark);
                DrawTree(head.Left, newIndent, "L");
                DrawTree(head.Right, newIndent, "R");
            }
        }
    }
}
