using System;
using System.Collections.Generic;

namespace GeekBrains.Learn.TreeTraversal
{
    class MathTree
    {
        private readonly Queue<Node> queue;
        private readonly Stack<Node> stack;

        public MathTree()
        {
            queue = new();
            stack = new();
        }

        /// <summary>
        /// breadth-first search - поиск в ширину
        /// using queue
        /// Метод визуально отображает последовательность перебора элементов
        /// </summary>
        public void DrawSearchBFS(Node head)
        {
            queue.Enqueue(head);

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
                Console.WriteLine(new string(' ', (node.Lvl - 1) * 2) + node.Value);

                if (node.Children != null)
                    foreach (var childrenNode in node.Children)
                        queue.Enqueue(childrenNode);
            }
        }

        /// <summary>
        /// deep-first search - поиск в глубину
        /// using stack
        /// Метод визуально отображает последовательность перебора элементов
        /// </summary>
        public void DrawSearchDFS(Node head)
        {
            stack.Push(head);

            while (stack.Count > 0)
            {
                Node node = stack.Pop();
                Console.WriteLine(new string(' ', (node.Lvl - 1) * 2) + node.Value);

                if (node.Children != null)
                    foreach (var childrenNode in node.Children)
                        stack.Push(childrenNode);
            }
        }
    }
}
