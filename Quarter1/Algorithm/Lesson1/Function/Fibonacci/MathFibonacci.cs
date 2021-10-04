namespace GeekBrains.Learn.Fibonacci
{
    class MathFibonacci
    {
        public ulong GetFibonacci(int itegrations)
        {
            if (itegrations == 0)
                return 0;
            if (itegrations == 1)
                return 1;
            return CalcFibonacci(itegrations - 1, 0, 1);
        }

        private ulong CalcFibonacci(int iterations, ulong lastNumber, ulong currentNumber)
        {
            iterations--;
            if (iterations == 0)
                return lastNumber + currentNumber;
            else
                return CalcFibonacci(iterations, currentNumber, lastNumber + currentNumber);
        }
    }
}
