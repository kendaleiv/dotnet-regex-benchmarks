using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;
using BenchmarkDotNet.Toolchains.DotNetCli;

namespace dotnet_regex_benchmarks
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
}
