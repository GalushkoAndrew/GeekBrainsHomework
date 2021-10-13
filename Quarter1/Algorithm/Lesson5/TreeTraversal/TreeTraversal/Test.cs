using System;
using System.Collections.Generic;

namespace GeekBrains.Learn.TreeTraversal
{
    class Test
    {
        private const int minLvlDepth = 4;
        private const int maxLvlDepth = 6;
        private const int minCountChildren = 2;
        private const int maxCountChildren = 5;

        private void GenerateChildren(Node head, int lvl = 1)
        {
            Random rnd = new();
            if (head.Lvl >= maxLvlDepth)
                return;

            if ((head.Lvl < minLvlDepth) || (head.Lvl >= minLvlDepth && Convert.ToBoolean(rnd.Next(0, 1))))
            {
                int childrenCount = rnd.Next(minCountChildren, maxCountChildren);
                for (int i = 1; i <= childrenCount; i++)
                {
                    Node newNode = new() 
                    {
                        Value = rnd.Next(
                            (int)Math.Pow(10, head.Lvl),
                            (int)Math.Pow(10, head.Lvl + 1) - 1),
                        Lvl = head.Lvl + 1,
                        Children = new List<Node>()
                    };
                    head.Children.Add(newNode);
                    GenerateChildren(newNode, lvl + 1);
                }
            }
        }

        public void Start()
        {
            MathTree mathTree = new();

            // генерим от 4 до 6 уровней
            // для каждого узла генерим от 2 до 5 детей
            Node head = new() { Value = 1, Lvl = 1, Children = new List<Node>() };
            GenerateChildren(head);

            Console.WriteLine("--------------------------");
            Console.WriteLine("DFS");
            Console.WriteLine("--------------------------");
            mathTree.DrawSearchBFS(head);
            Console.WriteLine("--------------------------");
            Console.WriteLine("BFS");
            Console.WriteLine("--------------------------");
            mathTree.DrawSearchDFS(head);
        }
    }
}
