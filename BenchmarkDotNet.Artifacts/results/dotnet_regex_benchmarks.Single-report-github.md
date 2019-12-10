``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18362
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.100
  [Host]        : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  .NET Core x64 : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  LegacyJitX86  : .NET Framework 4.8 (4.8.4042.0), X86 LegacyJIT
  RyuJitX64     : .NET Framework 4.8 (4.8.4042.0), X64 RyuJIT


```
|   Method |           Job |       Jit | Platform |     Toolchain |         Mean |      Error |     StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------- |-------------- |---------- |--------- |-------------- |-------------:|-----------:|-----------:|-------:|-------:|------:|----------:|
|   Normal | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 |     1.799 us |  0.0360 us |  0.0658 us | 0.7629 |      - |     - |   3.12 KB |
| Compiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 | 1,134.949 us |  6.3422 us |  5.6222 us | 1.9531 |      - |     - |  12.69 KB |
|   Normal |  LegacyJitX86 | LegacyJit |      X86 |         net48 |     2.380 us |  0.0472 us |  0.0505 us | 0.7172 |      - |     - |   2.94 KB |
| Compiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 |   631.919 us |  9.4512 us |  8.8406 us | 1.9531 | 0.9766 |     - |   9.41 KB |
|   Normal |     RyuJitX64 |    RyuJit |      X64 |         net48 |     2.076 us |  0.0144 us |  0.0112 us | 1.1139 |      - |     - |   4.57 KB |
| Compiled |     RyuJitX64 |    RyuJit |      X64 |         net48 | 1,167.988 us | 22.9845 us | 34.4021 us | 1.9531 |      - |     - |  14.37 KB |
