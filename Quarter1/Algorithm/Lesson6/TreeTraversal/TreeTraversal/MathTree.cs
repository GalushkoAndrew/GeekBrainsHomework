using System;
using System.Collections.Generic;

namespace GeekBrains.Learn.TreeTraversal
{
    class MathTree
    {
        private readonly Queue<int> queue;
        private readonly Stack<int> stack;
        private readonly int[,] matrix;
        private readonly int arraySize;
        private const int noEdge = 999;

        public MathTree(int[,] matrix)
        {
            queue = new();
            stack = new();
            this.matrix = matrix;
            arraySize = matrix.GetLength(0);
        }

        /// <summary>
        /// breadth-first search - поиск в ширину
        /// using queue
        /// Метод визуально отображает последовательность перебора элементов
        /// </summary>
        /// <param name="x">номер вершины, задающей точку старта, начиная с 0</param>
        /// <param name="nodes">список узлов</param>
        public void DrawGrafSearchBFS(int x, int[] nodes = null)
        {
            // Легенда для значений массива nodes. 0 = не пройден, 2 = пройден

            // инициализация массива с отметками о пройденных узлах
            if (nodes == null)
            {
                nodes = new int[arraySize];
                queue.Enqueue(x);
                Console.WriteLine("Очередность прохождения узлов:");
            }

            // если в очереди нет узлов, обход завершен
            if (queue.Count < 1)
            {
                return;
            }

            // извлекаем из очереди очередной узел
            int currentNode = queue.Dequeue();
            Console.WriteLine(currentNode);
            if (nodes[currentNode] == 0)
            {
                nodes[currentNode] = 2;
                // поиск смежных непройденных узлов
                for (int i = 0; i < arraySize; i++)
                {
                    if (matrix[currentNode, i] != noEdge && nodes[i] == 0)
                    {
                        queue.Enqueue(i);
                    }
                }
            }

            DrawGrafSearchBFS(x, nodes);
        }

        /// <summary>
        /// deep-first search - поиск в глубину
        /// using stack
        /// Метод визуально отображает последовательность перебора элементов
        /// </summary>
        /// <param name="x">номер вершины, задающей точку старта, начиная с 0</param>
        /// <param name="nodes">список узлов</param>
        public void DrawGrafSearchDFS(int x, int[] nodes = null)
        {
            // Легенда для значений массива nodes. 0 = не пройден, 1 = фронт волны, 2 = пройден

            // инициализация массива с отметками о пройденных узлах
            if (nodes == null)
            {
                nodes = new int[arraySize];
                nodes[x] = 1;
                stack.Push(x);
                Console.WriteLine("Очередность прохождения узлов:");
            }

            // если в очереди нет узлов, обход завершен
            if (stack.Count < 1)
            {
                return;
            }

            // извлекаем из очереди очередной узел
            int currentNode = stack.Pop();
            nodes[currentNode] = 2;
            Console.WriteLine(currentNode);

            // поиск смежных непройденных узлов
            for (int i = 0; i < arraySize; i++)
            {
                if (matrix[currentNode, i] != noEdge && nodes[i] < 1)
                {
                    stack.Push(i);
                }
            }

            DrawGrafSearchDFS(x, nodes);
        }
    }
}
