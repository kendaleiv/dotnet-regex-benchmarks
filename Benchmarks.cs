using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace dotnet_regex_benchmarks
{
    [Config(typeof(CustomPathsConfig))]
    [MemoryDiagnoser]
    public class SingleBenchmarks
    {
        [Benchmark]
        public void Normal() => new Regex("[A-Za-z0-9]").Match("abc");

        [Benchmark]
        public void Compiled() => new Regex("[A-Za-z0-9]", RegexOptions.Compiled).Match("abc");
    }

    [Config(typeof(CustomPathsConfig))]
    [MemoryDiagnoser]
    public class MultipleBenchmarks
    {
        [Params(1_000, 100_000, 1_000_000)]
        public int N;

        [Benchmark]
        public void Normal()
        {
            var regex = new Regex("[A-Za-z0-9]");

            for (var i = 0; i < N; i++)
            {
                regex.Match("abc");
            }
        }

        [Benchmark]
        public void Compiled()
        {
            var regex = new Regex("[A-Za-z0-9]", RegexOptions.Compiled);

            for (var i = 0; i < N; i++)
            {
                regex.Match("abc");
            }
        }
    }
}
