using BenchmarkDotNet.Running;
using System;

namespace GeekBrains.Learn.BenchmarkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Test>();
        }
    }
}
