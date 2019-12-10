``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18362
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.100
  [Host]        : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  .NET Core x64 : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  LegacyJitX86  : .NET Framework 4.8 (4.8.4042.0), X86 LegacyJIT
  RyuJitX64     : .NET Framework 4.8 (4.8.4042.0), X64 RyuJIT


```
|   Method |           Job |       Jit | Platform |     Toolchain |       Mean |    Error |    StdDev |     Median |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------- |-------------- |---------- |--------- |-------------- |-----------:|---------:|----------:|-----------:|--------:|-------:|------:|----------:|
|   Normal | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 |   174.0 us |  3.47 us |   7.61 us |   171.0 us | 50.2930 |      - |     - | 206.04 KB |
| Compiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 | 2,039.4 us | 40.86 us | 114.59 us | 2,038.8 us | 52.7344 | 1.9531 |     - | 215.63 KB |
|   Normal |  LegacyJitX86 | LegacyJit |      X86 |         net48 |   282.0 us | 10.30 us |  30.06 us |   269.0 us | 30.2734 |      - |     - | 124.09 KB |
| Compiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 | 1,000.6 us | 20.06 us |  28.12 us |   999.3 us | 31.2500 |      - |     - | 130.78 KB |
|   Normal |     RyuJitX64 |    RyuJit |      X64 |         net48 |   250.2 us |  9.52 us |  27.92 us |   256.2 us | 50.7813 |      - |     - | 208.09 KB |
| Compiled |     RyuJitX64 |    RyuJit |      X64 |         net48 | 1,361.3 us | 25.39 us |  26.07 us | 1,369.7 us | 52.7344 | 1.9531 |     - | 218.27 KB |
