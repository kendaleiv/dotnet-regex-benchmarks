``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18362
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.100
  [Host]        : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  .NET Core x64 : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  LegacyJitX86  : .NET Framework 4.8 (4.8.4042.0), X86 LegacyJIT
  RyuJitX64     : .NET Framework 4.8 (4.8.4042.0), X64 RyuJIT


```
|   Method |           Job |       Jit | Platform |     Toolchain |     Mean |    Error |   StdDev |     Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------- |-------------- |---------- |--------- |-------------- |---------:|---------:|---------:|----------:|--------:|------:|----------:|
|   Normal | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 | 17.08 ms | 0.341 ms | 0.466 ms | 4968.7500 |       - |     - |  19.84 MB |
| Compiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 | 16.94 ms | 0.245 ms | 0.229 ms | 4968.7500 |       - |     - |  19.85 MB |
|   Normal |  LegacyJitX86 | LegacyJit |      X86 |         net48 | 20.29 ms | 0.402 ms | 0.683 ms | 2937.5000 |       - |     - |  11.85 MB |
| Compiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 | 17.47 ms | 0.345 ms | 0.751 ms | 2937.5000 | 31.2500 |     - |  11.85 MB |
|   Normal |     RyuJitX64 |    RyuJit |      X64 |         net48 | 19.45 ms | 0.379 ms | 0.673 ms | 4968.7500 |       - |     - |   19.9 MB |
| Compiled |     RyuJitX64 |    RyuJit |      X64 |         net48 | 16.07 ms | 0.319 ms | 0.777 ms | 4968.7500 |       - |     - |  19.91 MB |
