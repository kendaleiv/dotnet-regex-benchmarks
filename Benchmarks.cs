using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
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

                Add(CsvMeasurementsExporter.Default);
                Add(RPlotExporter.Default);
            }
        }

        [Params(1, 1_000, 100_000, 1_000_000)]
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
