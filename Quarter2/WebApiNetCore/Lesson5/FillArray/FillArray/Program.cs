using System;

namespace GeekBrains.Learn.FillArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var work = new FillArrayEngine(5, 5);
            work.FillArray();
            work.PrintArray();
        }
    }

    public class FillArrayEngine
    {
        private readonly int[,] _array;

        /// <summary>
        /// количество символов для отображения цифры
        /// </summary>
        private int _spaceEdge = 0;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="x">array size x</param>
        /// <param name="y">array size y</param>
        public FillArrayEngine(int x, int y)
        {
            if (x < 1) {
                x = 1;
            }
            if (y < 1) {
                y = 1;
            }
            X = x;
            Y = y;
            _array = new int[y, x];

            _spaceEdge = (x * y).ToString().Length + 1;
        }

        public int X { get; }
        public int Y { get; }

        public void FillArray()
        {
            int maxValue = X * Y;
            int currentValue = 1;
            int currentX = 0;
            int currentY = 0;
            int countFilledLinesUp = 0;
            int countFilledLinesDown = 0;
            int countFilledLinesLeft = 0;
            int countFilledLinesRight = 0;
            int directionX = 1;
            int directionY = 0;

            while (currentValue <= maxValue)
            {
                _array[currentY, currentX] = currentValue;
                currentValue++;

                if (directionX == 1 && currentX == X - countFilledLinesRight - 1)
                {
                    directionX = 0;
                    directionY = 1;
                    countFilledLinesUp++;
                }
                else if (directionX == -1 && currentX == 0 + countFilledLinesLeft) {
                    directionX = 0;
                    directionY = -1;
                    countFilledLinesDown++;
                }
                else if (directionY == 1 && currentY == Y - countFilledLinesDown - 1) {
                    directionY = 0;
                    directionX = -1;
                    countFilledLinesRight++;
                }
                else if (directionY == -1 && currentY == 0 + countFilledLinesUp) {
                    directionY = 0;
                    directionX = 1;
                    countFilledLinesLeft++;
                }

                currentX += directionX;
                currentY += directionY;
            }
        }

        public void PrintArray()
        {
            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    Console.Write("{0, "+ _spaceEdge + "}", _array[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}
