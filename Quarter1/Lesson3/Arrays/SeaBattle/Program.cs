using System;
using System.Collections.Generic;

namespace GeekBrains.Learn.SeaBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            // 0 - нет ничего, 1 - корабль, 2 - пространство рядом с кораблем
            int[,] array = new int[10, 10];
            GenerateField(array);

            PrintField(array);
        }

        /// <summary>
        /// Создает поле и размещает на нем все корабли
        /// </summary>
        static void GenerateField(int[,] array)
        {
            List<Point> pointsAvaliable = new();
            for (int i = 0; i <= array.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= array.GetUpperBound(1); j++)
                {
                    pointsAvaliable.Add(new Point(i, j));
                }
            }

            Random rnd = new();
            GenerateShipKind(pointsAvaliable, rnd, array, 4, 1);
            GenerateShipKind(pointsAvaliable, rnd, array, 3, 2);
            GenerateShipKind(pointsAvaliable, rnd, array, 2, 3);
            GenerateShipKind(pointsAvaliable, rnd, array, 1, 4);
        }

        /// <summary>
        /// Размещает на поле все корабли заданного размера
        /// </summary>
        static void GenerateShipKind(List<Point> pointsAvaliable, Random rnd, int[,] array, int shipSize, int shipCount)
        {
            List<Point> pointsForSearch = new(pointsAvaliable);
            while (pointsForSearch.Count > 0 && shipCount > 0)
            {
                bool isShipPlaces = false;
                Point p = pointsForSearch[rnd.Next(0, pointsForSearch.Count - 1)];
                List<Direction> directions = new() { new Direction(-1, 0), new Direction(0, -1), new Direction(1, 0), new Direction(0, 1) };
                while (directions.Count > 0)
                {
                    Direction d = directions[rnd.Next(0, directions.Count - 1)];

                    if (CanPlace(array, p, d, shipSize))
                    {
                        PlaceShip(array, p, d, shipSize, pointsForSearch, pointsAvaliable);
                        shipCount--;
                        isShipPlaces = true;
                    }
                    else
                        directions.Remove(d);
                }

                if (directions.Count == 0 && !isShipPlaces)
                {
                    pointsForSearch.Remove(p);
                }
            }
        }

        /// <summary>
        /// Размещает корабль на поле
        /// </summary>
        static void PlaceShip(int[,] field, Point pointShip, Direction direction, int size, List<Point> pointsForSearch, List<Point> pointsAvaliable)
        {
            int x0 = direction.X >= 0 ? pointShip.X - 1 : pointShip.X - size;
            int y0 = direction.Y >= 0 ? pointShip.Y - 1 : pointShip.Y - size;
            int x1 = direction.X <= 0 ? pointShip.X + 1 : pointShip.X + size;
            int y1 = direction.Y <= 0 ? pointShip.Y + 1 : pointShip.Y + size;

            for (int x = x0; x <= x1; x++)
            {
                for (int y = y0; y <= y1; y++)
                {
                    if (x >= x0 + 1
                        && x <= x1 - 1
                        && y >= y0 + 1
                        && y <= y1 - 1)
                    {
                        field[x, y] = 1;
                        RemovePointFromList(pointsAvaliable, GetPointFromList(pointsAvaliable, x, y));
                    }
                    else
                    {
                        if (!(x < 0 || y < 0 || x > 9 || y > 9))
                            field[x, y] = 2;
                    }

                    RemovePointFromList(pointsForSearch, GetPointFromList(pointsForSearch, x, y));
                }
            }
        }

        /// <summary>
        /// Удаляет точку с координатами из списка
        /// </summary>
        static void RemovePointFromList(List<Point> list, Point p)
        {
            if (p != null)
                list.Remove(p);
        }

        /// <summary>
        /// Находит в списке точку с указанными координатами
        /// </summary>
        static Point GetPointFromList(List<Point> list, int x, int y)
        {
            foreach (var point in list)
            {
                if (point.X == x && point.Y == y)
                {
                    return point;
                }
            }

            return null;
        }

        /// <summary>
        /// Проверяет, можно ли разместить корабль по указанным координатам
        /// </summary>
        /// <param name="field">Игровое поле</param>
        /// <param name="pointShip">Координаты корабля</param>
        /// <param name="direction">Направление корабля</param>
        /// <param name="size">Размер корабля</param>
        /// <returns>Возвращает true, если корабль разместить можно</returns>
        static bool CanPlace(int[,] field, Point pointShip, Direction direction, int size)
        {
            int x0 = direction.X >= 0 ? pointShip.X - 1 : pointShip.X - size;
            int y0 = direction.Y >= 0 ? pointShip.Y - 1 : pointShip.Y - size;
            int x1 = direction.X <= 0 ? pointShip.X + 1 : pointShip.X + size;
            int y1 = direction.Y <= 0 ? pointShip.Y + 1 : pointShip.Y + size;

            if (x0 + 1 < 0
                || y0 + 1 < 0
                || x1 - 1 > 9
                || y1 - 1 > 9)
                return false;

            for (int x = x0; x <= x1; x++)
            {
                for (int y = y0; y <= y1; y++)
                {
                    if (!(x < 0 || y < 0 || x > 9 || y > 9)
                        && field[x, y] == 1)
                            return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Печать игрового поля
        /// </summary>
        /// <param name="array">Массив с игровым полем</param>
        static void PrintField(int[,] array)
        {
            Console.Write("  ");
            for (int i = 1; i < 11; i++)
            {
                Console.Write($"{i,2} ");
            }
            Console.WriteLine("");

            Console.Write(" ");
            Console.WriteLine(new string('-', 10 * 3 + 2));
            for (int x = 0; x <= array.GetUpperBound(0); x++)
            {
                Console.Write(Convert.ToChar(65 + x));
                Console.Write("|");
                for (int y = 0; y <= array.GetUpperBound(1); y++)
                {
                    char s = array[x, y] == 1 ? '0' : ' ';
                    Console.Write($" {s} ");
                }
                Console.WriteLine("|");
            }

            Console.Write(" ");
            Console.WriteLine(new string('-', 10 * 3 + 2));
            Console.WriteLine();
        }

        /// <summary>
        /// Позиция для размещения корабля
        /// </summary>
        class Point
        {
            public int X { get; }
            public int Y { get; }
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        /// <summary>
        /// Направление корабля от выбранной ранее стартовой позиции
        /// </summary>
        class Direction
        {
            public int X { get; }
            public int Y { get; }
            public Direction(int x, int y)
            {
                if (x != 0 && y != 0)
                {
                    X = 0;
                    Y = 0;
                }
                else
                {
                    X = Math.Sign(x);
                    Y = Math.Sign(y);
                }
            }
        }
    }
}
