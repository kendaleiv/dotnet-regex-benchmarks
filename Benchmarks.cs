using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;
using BenchmarkDotNet.Toolchains.DotNetCli;

namespace dotnet_regex_benchmarks
{
    [Config(typeof(CustomPathsConfig))]
    [MemoryDiagnoser]
    public class Benchmarks
    {
        // Reference: https://github.com/dotnet/BenchmarkDotNet/issues/534#issuecomment-328341718
        public class CustomPathsConfig : ManualConfig
        {
            public CustomPathsConfig() 
            {
                var netcoreapp31x64 = NetCoreAppSettings
                    .NetCoreApp31
                    .WithCustomDotNetCliPath(@"C:\Program Files\dotnet\dotnet.exe", ".NET Core x64");

                Add(Job.RyuJitX64.With(CsProjCoreToolchain.From(netcoreapp31x64)).WithId(".NET Core x64"));

                Add(Job.LegacyJitX86.With(CsProjClassicNetToolchain.Net48));
                Add(Job.RyuJitX64.With(CsProjClassicNetToolchain.Net48));
            }
        }

        [Benchmark]
        public void RegexSingleMatch()
        {
            new Regex("[A-Za-z0-9]").Match("abc");
        }

        [Benchmark]
        public void RegexSingleMatchCompiled()
        {
            new Regex("[A-Za-z0-9]", RegexOptions.Compiled).Match("abc");
        }

        [Benchmark]
        public void Regex1000Matches()
        {
            var regex = new Regex("[A-Za-z0-9]");

            for (var i = 0; i < 1000; i++)
            {
                regex.Match("abc");
            }
        }

        [Benchmark]
        public void Regex1000MatchesCompiled()
        {
            var regex = new Regex("[A-Za-z0-9]", RegexOptions.Compiled);

            for (var i = 0; i < 1000; i++)
            {
                regex.Match("abc");
            }
        }

        [Benchmark]
        public void Regex1000000Matches()
        {
            var regex = new Regex("[A-Za-z0-9]");

            for (var i = 0; i < 1000000; i++)
            {
                regex.Match("abc");
            }
        }

        [Benchmark]
        public void Regex1000000MatchesCompiled()
        {
            var regex = new Regex("[A-Za-z0-9]", RegexOptions.Compiled);

            for (var i = 0; i < 1000000; i++)
            {
                regex.Match("abc");
            }
        }
    }
}
