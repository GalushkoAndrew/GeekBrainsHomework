﻿using System;
using System.Collections.Generic;

namespace GeekBrains.Learn.TreeTraversal
{
    class Test
    {
        public void Start()
        {
            int[,] matrix = new int[18, 18]
            {
                {999, 2, 999, 999, 7, 5, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999},
                {2, 999, 999, 10, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999},
                {999, 999, 999, 11, 12, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999},
                {999, 10, 11, 999, 999, 999, 999, 999, 999, 16, 999, 999, 999, 999, 999, 999, 999, 999},
                {7, 999, 12, 999, 999, 999, 999, 999, 999, 999, 19, 999, 999, 999, 999, 999, 999, 999},
                {5, 999, 999, 999, 999, 999, 999, 7, 999, 999, 999, 999, 12, 999, 999, 999, 999, 999},
                {999, 999, 999, 999, 999, 999, 999, 6, 999, 999, 999, 999, 999, 999, 20, 999, 999, 999},
                {999, 999, 999, 999, 999, 7, 6, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999},
                {999, 999, 999, 999, 999, 999, 999, 999, 999, 3, 999, 999, 999, 999, 999, 999, 999, 999},
                {999, 999, 999, 16, 999, 999, 999, 999, 3, 999, 8, 4, 999, 999, 999, 999, 999, 999},
                {999, 999, 999, 999, 19, 999, 999, 999, 999, 8, 999, 999, 999, 999, 999, 999, 999, 999},
                {999, 999, 999, 999, 999, 999, 999, 999, 999, 4, 999, 999, 999, 8, 999, 999, 999, 999},
                {999, 999, 999, 999, 999, 12, 999, 999, 999, 999, 999, 999, 999, 999, 1, 999, 999, 999},
                {999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 8, 999, 999, 3, 999, 999, 999},
                {999, 999, 999, 999, 999, 999, 20, 999, 999, 999, 999, 999, 1, 3, 999, 999, 999, 999},
                {999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 2, 4},
                {999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 2, 999, 3},
                {999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 4, 3, 999}
            };

            MathTree mathTree = new(matrix);

            Console.WriteLine("--------------------------");
            Console.WriteLine("DFS");
            Console.WriteLine("--------------------------");
            mathTree.DrawGrafSearchBFS(0, null);
            Console.WriteLine("--------------------------");
            Console.WriteLine("BFS");
            Console.WriteLine("--------------------------");
            mathTree.DrawGrafSearchDFS(0, null);
        }
    }
}