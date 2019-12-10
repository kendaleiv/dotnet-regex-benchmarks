using BenchmarkDotNet.Running;

namespace dotnet_regex_benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var singleSummary = BenchmarkRunner.Run<Single>();
            var _1000Summary = BenchmarkRunner.Run<_1000>();
            var _100000Summary = BenchmarkRunner.Run<_100000>();
            var _1000000Summary = BenchmarkRunner.Run<_1000000>();
        }
    }
}
