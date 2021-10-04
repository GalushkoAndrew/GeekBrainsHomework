using System;

namespace GeekBrains.Learn.FunctionSimpleNumber
{
    /// <summary>
    /// Тест класса <see cref="MathSimple"/>
    /// </summary>
    class TestSimple
    {
        public TestSimple()
        {
            MathSimple mathSimple = new();
            int[] array = new int[] { 11, 23, 35, 98, 117 };
            foreach (var i in array)
            {
                string isSimpleText = mathSimple.IsSimple(i) ? "простое" : "не простое";
                Console.WriteLine($"{i} {isSimpleText} число.");
            }
        }
    }
}