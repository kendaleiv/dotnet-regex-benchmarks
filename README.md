# dotnet-regex-benchmarks

`> dotnet run -c Release -f netcoreapp3.1 --runtimes net48 netcoreapp3.1`

## Results

``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18362
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.100
  [Host]        : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  .NET Core x64 : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  LegacyJitX86  : .NET Framework 4.8 (4.8.4042.0), X86 LegacyJIT
  RyuJitX64     : .NET Framework 4.8 (4.8.4042.0), X64 RyuJIT


```
|   Method |           Job |       Jit | Platform |     Toolchain |       N |           Mean |         Error |         StdDev |      Gen 0 |   Gen 1 | Gen 2 |    Allocated |
|--------- |-------------- |---------- |--------- |-------------- |-------- |---------------:|--------------:|---------------:|-----------:|--------:|------:|-------------:|
|   **Normal** | **.NET Core x64** |    **RyuJit** |      **X64** | **.NET Core x64** |       **1** |       **1.613 us** |     **0.0319 us** |      **0.0592 us** |     **0.7629** |       **-** |     **-** |      **3.12 KB** |
| Compiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 |       1 |   1,056.890 us |    32.1328 us |     28.4848 us |     1.9531 |       - |     - |     12.69 KB |
|   Normal |  LegacyJitX86 | LegacyJit |      X86 |         net48 |       1 |       2.052 us |     0.0299 us |      0.0265 us |     0.7172 |       - |     - |      2.94 KB |
| Compiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 |       1 |     573.546 us |     6.2039 us |      5.4996 us |     1.9531 |  0.9766 |     - |      9.41 KB |
|   Normal |     RyuJitX64 |    RyuJit |      X64 |         net48 |       1 |       1.886 us |     0.0357 us |      0.0366 us |     1.1139 |       - |     - |      4.57 KB |
| Compiled |     RyuJitX64 |    RyuJit |      X64 |         net48 |       1 |   1,080.150 us |     6.5392 us |      6.1168 us |     1.9531 |       - |     - |     14.37 KB |
|   **Normal** | **.NET Core x64** |    **RyuJit** |      **X64** | **.NET Core x64** |    **1000** |     **156.056 us** |     **1.8793 us** |      **1.6659 us** |    **50.2930** |       **-** |     **-** |    **206.04 KB** |
| Compiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 |    1000 |   1,189.039 us |    10.9523 us |      9.1457 us |    52.7344 |  1.9531 |     - |    215.64 KB |
|   Normal |  LegacyJitX86 | LegacyJit |      X86 |         net48 |    1000 |     191.476 us |     0.9444 us |      0.8372 us |    30.2734 |       - |     - |    124.09 KB |
| Compiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 |    1000 |     728.065 us |     4.9772 us |      4.4122 us |    31.2500 |  0.9766 |     - |    130.78 KB |
|   Normal |     RyuJitX64 |    RyuJit |      X64 |         net48 |    1000 |     180.903 us |     1.8947 us |      1.7723 us |    50.7813 |       - |     - |    208.09 KB |
| Compiled |     RyuJitX64 |    RyuJit |      X64 |         net48 |    1000 |   1,312.849 us |    12.1146 us |     11.3320 us |    52.7344 |  1.9531 |     - |    218.27 KB |
|   **Normal** | **.NET Core x64** |    **RyuJit** |      **X64** | **.NET Core x64** |  **100000** |  **17,128.285 us** |   **285.3592 us** |    **266.9252 us** |  **4968.7500** |       **-** |     **-** |  **20315.43 KB** |
| Compiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 |  100000 |  15,367.899 us |   261.3481 us |    231.6782 us |  4968.7500 |       - |     - |  20324.91 KB |
|   Normal |  LegacyJitX86 | LegacyJit |      X86 |         net48 |  100000 |  20,953.448 us |   417.1268 us |    542.3827 us |  2937.5000 |       - |     - |   12130.2 KB |
| Compiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 |  100000 |  17,740.473 us |   339.2358 us |    300.7237 us |  2937.5000 | 31.2500 |     - |  12136.45 KB |
|   Normal |     RyuJitX64 |    RyuJit |      X64 |         net48 |  100000 |  20,505.209 us |   618.3088 us |    661.5835 us |  4968.7500 |       - |     - |  20376.89 KB |
| Compiled |     RyuJitX64 |    RyuJit |      X64 |         net48 |  100000 |  16,493.906 us |   319.7916 us |    267.0405 us |  4968.7500 |       - |     - |  20386.58 KB |
|   **Normal** | **.NET Core x64** |    **RyuJit** |      **X64** | **.NET Core x64** | **1000000** | **170,817.714 us** | **4,472.9357 us** | **12,905.4421 us** | **49666.6667** |       **-** |     **-** | **203127.91 KB** |
| Compiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 | 1000000 | 130,691.045 us | 2,173.4056 us |  1,926.6675 us | 49500.0000 |       - |     - | 203137.41 KB |
|   Normal |  LegacyJitX86 | LegacyJit |      X86 |         net48 | 1000000 | 199,408.749 us | 3,969.8321 us |  8,713.8778 us | 29333.3333 |       - |     - | 121276.94 KB |
| Compiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 | 1000000 | 158,170.834 us | 3,162.3895 us |  5,538.6701 us | 29500.0000 |       - |     - | 121282.28 KB |
|   Normal |     RyuJitX64 |    RyuJit |      X64 |         net48 | 1000000 | 182,724.275 us | 4,590.5430 us |  5,464.7148 us | 49666.6667 |       - |     - | 203728.15 KB |
| Compiled |     RyuJitX64 |    RyuJit |      X64 |         net48 | 1000000 | 141,131.531 us | 2,790.0185 us |  5,441.7167 us | 49500.0000 |       - |     - | 203738.77 KB |
