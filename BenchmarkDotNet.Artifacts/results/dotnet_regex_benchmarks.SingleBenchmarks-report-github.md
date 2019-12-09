``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18362
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.100
  [Host]        : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  .NET Core x64 : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  LegacyJitX86  : .NET Framework 4.8 (4.8.4042.0), X86 LegacyJIT
  RyuJitX64     : .NET Framework 4.8 (4.8.4042.0), X64 RyuJIT


```
|   Method |           Job |       Jit | Platform |     Toolchain |         Mean |      Error |     StdDev |       Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------- |-------------- |---------- |--------- |-------------- |-------------:|-----------:|-----------:|-------------:|-------:|-------:|------:|----------:|
|   Normal | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 |     1.693 us |  0.0189 us |  0.0158 us |     1.692 us | 0.7629 |      - |     - |   3.12 KB |
| Compiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 | 1,081.061 us | 21.3221 us | 38.4481 us | 1,058.883 us | 1.9531 |      - |     - |  12.68 KB |
|   Normal |  LegacyJitX86 | LegacyJit |      X86 |         net48 |     2.051 us |  0.0193 us |  0.0161 us |     2.047 us | 0.7172 |      - |     - |   2.94 KB |
| Compiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 |   570.049 us |  1.9102 us |  1.4913 us |   570.107 us | 1.9531 | 0.9766 |     - |   9.41 KB |
|   Normal |     RyuJitX64 |    RyuJit |      X64 |         net48 |     1.862 us |  0.0307 us |  0.0287 us |     1.853 us | 1.1139 |      - |     - |   4.57 KB |
| Compiled |     RyuJitX64 |    RyuJit |      X64 |         net48 | 1,086.611 us | 10.3822 us |  9.7115 us | 1,084.014 us | 1.9531 |      - |     - |  14.37 KB |
