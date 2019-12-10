``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18362
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.100
  [Host]        : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  .NET Core x64 : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  LegacyJitX86  : .NET Framework 4.8 (4.8.4042.0), X86 LegacyJIT
  RyuJitX64     : .NET Framework 4.8 (4.8.4042.0), X64 RyuJIT


```
|   Method |           Job |       Jit | Platform |     Toolchain |     Mean |   Error |   StdDev |   Median |      Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------- |-------------- |---------- |--------- |-------------- |---------:|--------:|---------:|---------:|-----------:|------:|------:|----------:|
|   Normal | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 | 170.3 ms | 6.86 ms |  8.17 ms | 166.6 ms | 49500.0000 |     - |     - | 198.37 MB |
| Compiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 | 145.0 ms | 2.86 ms |  6.50 ms | 144.0 ms | 49500.0000 |     - |     - | 198.38 MB |
|   Normal |  LegacyJitX86 | LegacyJit |      X86 |         net48 | 203.5 ms | 4.02 ms |  6.60 ms | 202.3 ms | 29333.3333 |     - |     - | 118.43 MB |
| Compiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 | 173.8 ms | 3.36 ms |  4.93 ms | 172.5 ms | 29500.0000 |     - |     - | 118.44 MB |
|   Normal |     RyuJitX64 |    RyuJit |      X64 |         net48 | 207.7 ms | 4.46 ms | 13.07 ms | 203.7 ms | 49666.6667 |     - |     - | 198.95 MB |
| Compiled |     RyuJitX64 |    RyuJit |      X64 |         net48 | 141.9 ms | 1.92 ms |  1.80 ms | 142.2 ms | 49500.0000 |     - |     - | 198.96 MB |
