using System;
using System.Globalization;

namespace GeekBrains.Learn.DinamicProgramming
{
    class Test
    {
        public void Start(int M, int N)
        {
            MathCalc mathCalc = new MathCalc();
            var nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = " ";

            try
            {
                Console.WriteLine($"Для таблицы {M} * {N} количество путей = {mathCalc.GetCountPaths(M, N).ToString("#,0", nfi)}");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Слишком большой размер поля, уменьшите его.");
            }
        }
    }
}
