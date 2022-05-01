using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GeekBrains.Learn.Cross
{
    internal sealed class CrossGame
    {
        // 3. Определяем размеры массива
        int SIZE_X = 3;
        int SIZE_Y = 3;

        // 1. Создаем двумерный массив
        char[,] field;

        // 2. Обозначаем кто будет ходить какими фишками
        public char PLAYER_DOT = 'X';
        public char AI_DOT = '0';
        char EMPTY_DOT = '.';

        // 17. Определяем размер победной длины
        int WinLength;

        // 12. Создаем рандом
        static Random _rand = new();

        /// <inheritdoc/>
        public CrossGame(int x, int y, int winLength)
        {
            SIZE_X = x;
            SIZE_Y = y;
            WinLength = winLength;
            field = new char[SIZE_Y, SIZE_X];
        }

        // 4. Заполняем на массив
        public void InitField()
        {
            for (int i = 0; i < SIZE_Y; i++) {
                for (int j = 0; j < SIZE_X; j++) {
                    field[i, j] = EMPTY_DOT;
                }
            }
        }

        // 5. Выводим на массив на печать
        public void PrintField()
        {
            //6. украшаем картинку
            Console.WriteLine(new string('-', SIZE_X * 2 + 1));
            for (int i = 0; i < SIZE_Y; i++) {
                Console.Write("|");
                for (int j = 0; j < SIZE_X; j++) {
                    Console.Write(field[i, j] + "|");
                }
                Console.WriteLine();
            }
            //6. украшаем картинку
            Console.WriteLine(new string('-', SIZE_X * 2 + 1));
        }

        // 10. Проверяем возможен ли ход
        private bool IsCellValid(int y, int x)
        {
            // если вываливаемся за пределы возвращаем false
            if (x < 0 || y < 0 || x > SIZE_X - 1 || y > SIZE_Y - 1) {
                return false;
            }
            // если не пустое поле тоже false
            return (field[y, x] == EMPTY_DOT);
        }

        // 7. Метод который устанавливает символ
        private void SetSym(int y, int x, char sym)
        {
            field[y, x] = sym;
        }

        // 9. Ход игрока
        public void PlayerStep()
        {
            // 11. с проверкой
            int x;
            int y;
            do {
                Console.WriteLine($"Введите координаты: X Y (1-{SIZE_X} 1-{SIZE_Y})");
                x = int.Parse(Console.ReadLine()) - 1;
                y = int.Parse(Console.ReadLine()) - 1;
            } while (!IsCellValid(y, x));
            SetSym(y, x, PLAYER_DOT);
        }

        // 13. Ход ПК
        public void AiSteps()
        {
            // Анализ своей ситуации
            // Находим все фигуры на поле
            var aiFigures = GetFiguresOnField(AI_DOT);
            // Оставляем только те, которыми можно победить
            aiFigures = GetPotentialFigures(aiFigures, AI_DOT);

            // Анализ ситуации противника
            var playerFigures = GetFiguresOnField(PLAYER_DOT);
            // Оставляем только те, которыми можно победить
            playerFigures = GetPotentialFigures(playerFigures, PLAYER_DOT);

            // выбор хода
            var newPoint = GetNextMove(aiFigures, playerFigures);
            SetSym(newPoint.Y, newPoint.X, AI_DOT);
        }

        /// <summary>
        /// 27. Выбор лучшей фигуры из имеющихся
        /// </summary>
        /// <param name="figures">список фигур</param>
        private Figure GetBestFigure(List<Figure> figures)
        {
            Figure tmpFigure = figures.OrderBy(x => x.Cost).FirstOrDefault();

            if (tmpFigure != null) {
                var bestFigures = figures
                    .Where(x => x.Cost == tmpFigure.Cost)
                    .ToList();

                if (bestFigures.Count > 1) {
                    var maxLength = bestFigures
                        .Select(x => x.PotentialLength)
                        .Max();
                    bestFigures = bestFigures
                        .Where(x => x.PotentialLength == maxLength)
                        .ToList();
                    return bestFigures[_rand.Next(bestFigures.Count)];
                }
                else {
                    return bestFigures.FirstOrDefault();
                }
            }
            return null;
        }

        /// <summary>
        /// 28. Выбор лучшего хода
        /// </summary>
        /// <param name="myFigures"></param>
        /// <param name="hisFigures"></param>
        /// <returns><see cref="Point"/></returns>
        private Point GetNextMove(List<Figure> myFigures, List<Figure> hisFigures)
        {
            Figure myBestFigure = GetBestFigure(myFigures);
            Figure hisBestFigure = GetBestFigure(hisFigures);

            // если у нас выигрышная ситуация, ходим на выигрыш
            if (myBestFigure != null && myBestFigure.Cost == 1) {
                return myBestFigure.PotentialPoint;
            }
            if (hisBestFigure != null && hisBestFigure.Cost == 1) {
                return hisBestFigure.PotentialPoint;
            }

            // если раньше не ходил, то следующий ход случайный
            if (myBestFigure == null) {
                List<Point> emptiPoints = FieldEmptyPoints();
                if (emptiPoints.Count == 0) {
                    return null;
                }
                return emptiPoints[_rand.Next(emptiPoints.Count)];
            }
            return myBestFigure.PotentialPoint;
        }

        /// <summary>
        /// 29. Получаем список точек, доступных для хода
        /// </summary>
        /// <returns></returns>
        private List<Point> FieldEmptyPoints()
        {
            List<Point> list = new();
            for (int x = 0; x < SIZE_X; x++) {
                for (int y = 0; y < SIZE_Y; y++) {
                    if (field[y, x] == EMPTY_DOT) {
                        list.Add(new Point(x, y));
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 20. Находит все отрезки на поле
        /// </summary>
        /// <returns></returns>
        private List<Figure> GetFiguresOnField(char dot)
        {
            int dx = 1;
            int dy = 0;
            List<Figure> result = new();
            Figure figure;

            // Находим все горизонтальные отрезки
            for (int y = 0; y < SIZE_Y; y++) {
                int x = 0;
                figure = null;
                while (x < SIZE_X) {
                    figure = AddToFigure(x, y, dx, dy, result, figure, dot);
                    x += dx;
                }
            }

            // Находим все вертикальные отрезки
            dx = 0;
            dy = 1;
            for (int x = 0; x < SIZE_X; x++) {
                int y = 0;
                figure = null;
                while (y < SIZE_Y) {
                    figure = AddToFigure(x, y, dx, dy, result, figure, dot);
                    y += dy;
                }
            }

            // Находим все отрезки наискосок. Лево-верх, право-низ
            // для левой стороны
            dx = 1;
            dy = 1;
            for (int startY = 0; startY < SIZE_Y; startY++) {
                int y = startY;
                int x = 0;
                figure = null;
                do {
                    figure = AddToFigure(x, y, dx, dy, result, figure, dot);
                    x += dx;
                    y += dy;
                } while (x + dx < SIZE_X && y + dy < SIZE_Y);
            }

            for (int startX = 1; startX < SIZE_X; startX++) {
                int x = startX;
                int y = 0;
                figure = null;
                do {
                    figure = AddToFigure(x, y, dx, dy, result, figure, dot);
                    x += dx;
                    y += dy;
                } while (x + dx < SIZE_X && y + dy < SIZE_Y);
            }

            // Находим все отрезки наискосок. Право-верх, лево-низ.
            // для левой стороны
            dx = -1;
            dy = 1;

            for (int startY = 0; startY < SIZE_Y; startY++) {
                int y = startY;
                int x = SIZE_X - 1;
                figure = null;
                do {
                    figure = AddToFigure(x, y, dx, dy, result, figure, dot);
                    x += dx;
                    y += dy;
                } while (x + dx >= 0 && y + dy < SIZE_Y);
            }

            for (int startX = SIZE_X - 2; startX >= 0; startX--) {
                int x = startX;
                int y = 0;
                figure = null;
                do {
                    figure = AddToFigure(x, y, dx, dy, result, figure, dot);
                    x += dx;
                    y += dy;
                } while (x + dx >= 0 && y + dy < SIZE_Y);
            }

            return result;
        }

        /// <summary>
        /// 21. Внутренний шаг поиска фигур на поле
        /// </summary>
        private Figure AddToFigure(int x, int y, int directionX, int directionY, List<Figure> result, Figure figure, char dot)
        {
            if (field[y, x] == dot) {
                if (figure == null) {
                    figure = new Figure(directionX, directionY);
                    result.Add(figure);
                    figure.Points.Add(new Point(x, y));
                }
                else {
                    figure.Points.Add(new Point(x, y));
                }
            }
            else {
                figure = null;
            }
            return figure;
        }

        /// <summary>
        /// 22. Определение фигур, которыми можно победить и их ценности
        /// Анализ идет на 1 ход вперед
        /// </summary>
        private List<Figure> GetPotentialFigures(List<Figure> figures, char dot)
        {
            var newFigures = new List<Figure>();
            foreach (var figure in figures) {
                int length = figure.Points.Count;
                var pointStart = figure.Points.First();
                int x = pointStart.X;
                int y = pointStart.Y;
                int dx = figure.DirectionX * -1;
                int dy = figure.DirectionY * -1;
                int avaliableLengthStart = GetPossibleLength(x, y, dx, dy, WinLength, length, dot);
                int lengthAddAfterMoveStart = avaliableLengthStart == 0 ? 0 : Forecast(dx, dy, figure, pointStart);

                var pointEnd = figure.Points.Last();
                x = pointEnd.X;
                y = pointEnd.Y;
                dx = figure.DirectionX;
                dy = figure.DirectionY;
                int avaliableLengthEnd = GetPossibleLength(x, y, dx, dy, WinLength, length, dot);
                int lengthAddAfterMoveEnd = avaliableLengthEnd == 0 ? 0 : Forecast(dx, dy, figure, pointEnd);

                if (lengthAddAfterMoveStart > lengthAddAfterMoveEnd) {
                    figure.PotentialLength = length + lengthAddAfterMoveStart;
                    figure.PotentialPoint = new Point(pointStart.X + figure.DirectionX * -1, pointStart.Y + figure.DirectionY * -1);
                }
                else {
                    figure.PotentialLength = length + lengthAddAfterMoveEnd;
                    figure.PotentialPoint = new Point(pointEnd.X + figure.DirectionX, pointEnd.Y + figure.DirectionY);
                }

                if (length + avaliableLengthStart + avaliableLengthEnd >= WinLength) {
                    figure.Cost = GetCost(
                        avaliableLengthStart,
                        avaliableLengthEnd,
                        lengthAddAfterMoveStart,
                        lengthAddAfterMoveEnd,
                        length,
                        WinLength);
                    newFigures.Add(figure);
                }
            }
            return newFigures;
        }

        /// <summary>
        /// Прогноз хода
        /// Возвращает длину добавляемого к фигуре отрезка
        /// </summary>
        private int Forecast(int dx, int dy, Figure figure, Point startPoint)
        {
            if (!((dx == figure.DirectionX && dy == figure.DirectionY)
                || (dx == figure.DirectionX * -1 && dy == figure.DirectionY * -1))) {
                return 0;
            }
            int newLength = 1;
            int x = startPoint.X + dx;
            int y = startPoint.Y + dy;
            while (!IsGetBorder(x + dx, GetEndCoordinate(SIZE_X, dx), dx)
                && !IsGetBorder(y + dy, GetEndCoordinate(SIZE_Y, dy), dy)
               && field[y + dy, x + dx] == field[startPoint.Y, startPoint.X]) {
                newLength++;
                x += dx;
                y += dy;
            }
            return newLength;
        }

        /// <summary>
        /// 25. Внутренняя логика, определяем возможную длину фигуры в одном направлении
        /// </summary>
        /// <returns></returns>
        private int GetPossibleLength(int x, int y, int dx, int dy, int sizeWin, int possibleLength, char dot)
        {
            int avaliableLength = 0;
            while (possibleLength + avaliableLength < sizeWin
                && !IsGetBorder(x + dx, GetEndCoordinate(SIZE_X, dx), dx)
                && !IsGetBorder(y + dy, GetEndCoordinate(SIZE_Y, dy), dy)) {
                x += dx;
                y += dy;
                if (field[y, x] == EMPTY_DOT || field[y, x] == dot) {
                    avaliableLength++;
                }
                else {
                    break;
                }
            }
            return avaliableLength;
        }

        /// <summary>
        /// 26. Оценка ценности фигуры
        /// Лучшая оценка - меньшая
        /// </summary>
        private int GetCost(
            int avaliableLengthStart,
            int avaliableLengthEnd,
            int lengthAddAfterMoveStart,
            int lengthAddAfterMoveEnd,
            int length,
            int aim)
        {
            if ((aim - length == 1)
                && (avaliableLengthStart > 0 || avaliableLengthEnd > 0)) {
                return 1;
            }
            if (avaliableLengthStart >= aim - length && avaliableLengthEnd >= aim - length) {
                if (length == aim - 2) {
                    return 1;
                }
                if ((length + lengthAddAfterMoveStart >= aim - 1)
                    || (length + lengthAddAfterMoveEnd >= aim - 1)) {
                    return 1;
                }
                return 2;
            }
            if ((avaliableLengthStart >= aim - length && avaliableLengthEnd >= 0)
                || (avaliableLengthStart >= 0 && avaliableLengthEnd >= aim - length)) {
                return 3;
            }
            if (avaliableLengthStart >= 0 && avaliableLengthEnd >= 0) {
                return 4;
            }
            return 5;
        }

        /// <summary>
        /// 23. Вспомогательный шаг, определяет границу поиска
        /// </summary>
        /// <returns></returns>
        private int GetEndCoordinate(int size, int direction)
        {
            if (direction == -1) {
                return 0;
            }
            else {
                return size;
            }
        }

        /// <summary>
        /// 24. Вспомогательный шаг, сообщает находится ли координата за границей поля
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="border"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private bool IsGetBorder(int coordinate, int border, int direction)
        {
            if (direction > 0) {
                if (coordinate >= border) {
                    return true;
                }
                return false;
            }
            if (direction < 0) {
                if (coordinate < 0) {
                    return true;
                }
                return false;
            }
            return false;
        }

        // 14. Проверка победы
        public bool CheckWin(char sym)
        {
            var figures = GetFiguresOnField(sym);
            if (figures.Where(x => x.Points.Count >= WinLength).Any()) {
                return true;
            }
            return false;
        }

        // 16. Проверка полное ли поле? возможно ли ходить?
        public bool IsFieldFull()
        {
            for (int i = 0; i < SIZE_Y; i++) {
                for (int j = 0; j < SIZE_X; j++) {
                    if (field[i, j] == EMPTY_DOT) {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 18. Список точек, образующих прямой отрезок
        /// </summary>
        [DebuggerDisplay("{ToString()}")]
        private class Figure
        {
            public Figure(int directionX, int directionY)
            {
                Points = new List<Point>();
                DirectionX = directionX;
                DirectionY = directionY;
            }

            /// <summary>
            /// Список точек, образующих отрезок
            /// Хранятся сверху вниз, слева направо.
            /// Именно в таком порядке (касается случая, когда направления конфликтуют).
            /// </summary>
            public List<Point> Points { get; set; }

            /// <summary>
            /// Направление фигуры в списке по координатам X
            /// </summary>
            public int DirectionX { get; set; }

            /// <summary>
            /// Направление фигуры в списке по координатам Y
            /// </summary>
            public int DirectionY { get; set; }

            /// <summary>
            /// Оценка приоритетности построения фигуры
            /// </summary>
            public int Cost { get; set; }

            /// <summary>
            /// Потенциальная длина фигуры после хода
            /// </summary>
            public int PotentialLength { get; set; }

            /// <summary>
            /// Лучший потенциальный ход
            /// </summary>
            public Point PotentialPoint { get; set; }

            public override string ToString()
            {
                return "Точек: " + Points.Count.ToString();
            }
        }

        /// <summary>
        /// 19. Точка
        /// </summary>
        [DebuggerDisplay("{ToString()}")]
        private class Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }

            public override string ToString()
            {
                return "X = " + X.ToString() + ", Y = " + Y.ToString();
            }
        }
    }
}
