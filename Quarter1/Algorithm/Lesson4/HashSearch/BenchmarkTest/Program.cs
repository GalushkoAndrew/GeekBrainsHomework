using BenchmarkDotNet.Running;

namespace GeekBrains.Learn.BenchmarkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test test = new();
            //test.Start();
            BenchmarkRunner.Run<Test>();
        }
    }
}
