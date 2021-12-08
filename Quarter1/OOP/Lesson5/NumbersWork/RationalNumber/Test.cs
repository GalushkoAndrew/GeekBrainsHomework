namespace GeekBrains.Learn.Numbers.Rational
{

    /// <summary>
    /// Класс, содержащий тесты
    /// </summary>
    internal sealed class Test
    {
        /// <summary>
        /// Запуск теста
        /// </summary>
        public void Start()
        {
            ConsoleLogger logger = new();

            RationalNumber r1 = new(12, 7);
            logger.SendLine(r1.ToString());
            RationalNumber r2 = new(0, 7);
            logger.SendLine(r2.ToString());
            RationalNumber r3 = new(10, 1);
            logger.SendLine(r3.ToString());
            RationalNumber r4 = new(15, 0);
            logger.SendLine(r4.ToString());
            RationalNumber r5 = new(1564, 3);
            logger.SendLine(r5.ToString());
            logger.DrawLine();

            logger.SendLine(r5.ToInt().ToString());
            logger.SendLine(r5.ToFloat().ToString());
            logger.SendLine(((float)r5).ToString());
            logger.SendLine(((int)r5).ToString());
            logger.DrawLine();

            RationalNumber r6 = new(6, 2);
            RationalNumber r7 = new(15, 5);
            if (r6 == r7)
            {
                logger.SendLine($"Числа {r6} и {r7} равны.");
            }

            if (r6.Equals(r7))
            {
                logger.SendLine($"Числа {r6} и {r7} равны через Equals.");
            }

            if (r6 != r1)
            {
                logger.SendLine($"Числа {r6} и {r1} не равны.");
            }

            if (r6 > r1)
            {
                logger.SendLine($"{r6} > {r1}");
            }

            if (r1 < r6)
            {
                logger.SendLine($"{r1} < {r6}");
            }

            if (r6 >= r1)
            {
                logger.SendLine($"{r6} >= {r1}");
            }

            if (r1 <= r6)
            {
                logger.SendLine($"{r1} <= {r6}");
            }

            if (r7 <= r6)
            {
                logger.SendLine($"{r7} <= {r6}");
            }

            logger.SendLine($"{r6} - {r7} = {r6 - r7}");
            logger.SendLine($"{r6} - {r1} = {r6 - r1}");
            logger.SendLine($"++{r1} = " + $"{++r1}");
            logger.SendLine($"--{r1} = " + $"{--r1}");
            logger.SendLine($"{r6} * {r7} = {r6 * r7}");
            logger.SendLine($"{r6} / {r5} = {r6 / r5}");
            RationalNumber r8 = new(7, 5);
            RationalNumber r9 = new(1, 2);
            logger.SendLine($"{r8} % {r9} = {r8 % r9}");
            logger.SendLine($"{r6} % {r5} = {r6 % r5}");
        }
    }
}
