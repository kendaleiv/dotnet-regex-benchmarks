using BenchmarkDotNet.Running;

namespace dotnet_regex_benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var singleBenchmarksSummary = BenchmarkRunner.Run<SingleBenchmarks>();
            var multipleBenchmarksSummary = BenchmarkRunner.Run<MultipleBenchmarks>();
        }
    }
}