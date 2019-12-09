``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18362
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.100
  [Host]        : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  .NET Core x64 : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  LegacyJitX86  : .NET Framework 4.8 (4.8.4042.0), X86 LegacyJIT
  RyuJitX64     : .NET Framework 4.8 (4.8.4042.0), X64 RyuJIT


```
|   Method |           Job |       Jit | Platform |     Toolchain |       N |         Mean |       Error |      StdDev |      Gen 0 |   Gen 1 | Gen 2 |    Allocated |
|--------- |-------------- |---------- |--------- |-------------- |-------- |-------------:|------------:|------------:|-----------:|--------:|------:|-------------:|
|   **Normal** | **.NET Core x64** |    **RyuJit** |      **X64** | **.NET Core x64** |    **1000** |     **159.4 us** |     **2.91 us** |     **2.58 us** |    **50.2930** |       **-** |     **-** |    **206.04 KB** |
| Compiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 |    1000 |   1,187.2 us |     8.13 us |     6.79 us |    52.7344 |  1.9531 |     - |    215.63 KB |
|   Normal |  LegacyJitX86 | LegacyJit |      X86 |         net48 |    1000 |     189.6 us |     0.84 us |     0.70 us |    30.2734 |       - |     - |    124.09 KB |
| Compiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 |    1000 |     728.0 us |     5.72 us |     5.07 us |    31.2500 |  0.9766 |     - |    130.78 KB |
|   Normal |     RyuJitX64 |    RyuJit |      X64 |         net48 |    1000 |     182.0 us |     1.44 us |     1.35 us |    50.7813 |       - |     - |    208.09 KB |
| Compiled |     RyuJitX64 |    RyuJit |      X64 |         net48 |    1000 |   1,222.0 us |     8.46 us |     7.91 us |    52.7344 |  1.9531 |     - |    218.27 KB |
|   **Normal** | **.NET Core x64** |    **RyuJit** |      **X64** | **.NET Core x64** |  **100000** |  **15,514.3 us** |    **69.23 us** |    **61.37 us** |  **4968.7500** |       **-** |     **-** |  **20315.44 KB** |
| Compiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 |  100000 |  14,102.4 us |   173.97 us |   162.73 us |  4968.7500 |       - |     - |  20325.01 KB |
|   Normal |  LegacyJitX86 | LegacyJit |      X86 |         net48 |  100000 |  19,042.8 us |   273.93 us |   242.83 us |  2937.5000 |       - |     - |   12130.2 KB |
| Compiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 |  100000 |  16,210.7 us |   200.77 us |   167.66 us |  2937.5000 | 31.2500 |     - |  12136.45 KB |
|   Normal |     RyuJitX64 |    RyuJit |      X64 |         net48 |  100000 |  17,764.6 us |   108.60 us |    96.27 us |  4968.7500 |       - |     - |  20376.89 KB |
| Compiled |     RyuJitX64 |    RyuJit |      X64 |         net48 |  100000 |  14,485.2 us |   248.97 us |   232.88 us |  4968.7500 |       - |     - |  20389.75 KB |
|   **Normal** | **.NET Core x64** |    **RyuJit** |      **X64** | **.NET Core x64** | **1000000** | **152,994.5 us** |   **997.49 us** |   **884.25 us** | **49666.6667** |       **-** |     **-** | **203128.35 KB** |
| Compiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 | 1000000 | 129,001.7 us | 2,034.83 us | 1,903.38 us | 49500.0000 |       - |     - | 203137.41 KB |
|   Normal |  LegacyJitX86 | LegacyJit |      X86 |         net48 | 1000000 | 190,623.3 us | 3,654.76 us | 3,239.85 us | 29333.3333 |       - |     - | 121276.94 KB |
| Compiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 | 1000000 | 150,701.8 us |   553.87 us |   518.09 us | 29500.0000 |       - |     - | 121282.28 KB |
|   Normal |     RyuJitX64 |    RyuJit |      X64 |         net48 | 1000000 | 182,966.4 us | 2,580.10 us | 2,413.43 us | 49666.6667 |       - |     - | 203728.15 KB |
| Compiled |     RyuJitX64 |    RyuJit |      X64 |         net48 | 1000000 | 131,543.7 us | 1,604.60 us | 1,339.91 us | 49500.0000 |       - |     - | 203738.75 KB |
