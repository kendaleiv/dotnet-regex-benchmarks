using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace dotnet_regex_benchmarks
{
    [Config(typeof(CustomPathsConfig))]
    [MemoryDiagnoser]
    public class Single
    {
        [Benchmark]
        public void Normal() => new Regex("[A-Za-z0-9]").Match("abc");

        [Benchmark]
        public void Compiled() => new Regex("[A-Za-z0-9]", RegexOptions.Compiled).Match("abc");
    }

    [Config(typeof(CustomPathsConfig))]
    [MemoryDiagnoser]
    public class _1000
    {
        public int N = 1000;

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

    [Config(typeof(CustomPathsConfig))]
    [MemoryDiagnoser]
    public class _100000
    {
        public int N = 100000;

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

    [Config(typeof(CustomPathsConfig))]
    [MemoryDiagnoser]
    public class _1000000
    {
        
        public int N = 1000000;

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
