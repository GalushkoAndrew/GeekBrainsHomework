using System.Collections.Generic;
using System.Linq;

namespace GeekBrains.Learn.DinamicProgramming
{
    class MathCalc
    {
        /// <summary>
        /// Рассчитывает количество вариантов путей в прямоугольном поле
        /// из левого верхнего угла в правый нижний
        /// двигаться можно только на 1 клетку вниз или вправо
        /// </summary>
        /// <param name="M">количество колонок</param>
        /// <param name="N">количество строк</param>
        /// <returns></returns>
        public long GetCountPaths(int M, int N)
        {
            if (M == 1 || N == 1)
            {
                return 1;
            }

            // массив, ограничен размерами M * (N - 1)
            List<Point> points = new();

            // каждый шаг - это расчет вариантов прохождения колонки,
            // которые будут использоваться в расчете следующей колонки

            // варианты для первой колонки заполняем единицами
            for (int row = 1; row < N; row++)
            {
                points.Add(new Point() { Mx = 1, Nx = row, VariantCount = 1 });
            }

            for (int column = 2; column <= M; column++)
            {
                for (int row = N - 1; row > 0; row--)
                {
                    var sum = points
                        .Where(x => (x.Mx == column - 1) && (x.Nx <= row))
                        .Select(x => x.VariantCount)
                        .Sum();
                    points.Add(new Point() { Mx = column, Nx = row, VariantCount = sum });
                }
            }

            int maxIndex = (M - 1) * (N - 1) + 1;
            int step = N - 1;
            long result = 0;
            for (int x = 0; x < maxIndex; x += step)
            {
                result += points[x].VariantCount;
            }

            return result;
        }

        struct Point
        {
            public int Mx { get; set; }
            public int Nx { get; set; }
            public long VariantCount { get; set; }
        }
    }
}
