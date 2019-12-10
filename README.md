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

### Single

|   Method |           Job |       Jit | Platform |     Toolchain |         Mean |      Error |     StdDev |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------- |-------------- |---------- |--------- |-------------- |-------------:|-----------:|-----------:|-------:|-------:|------:|----------:|
|   Normal | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 |     1.799 us |  0.0360 us |  0.0658 us | 0.7629 |      - |     - |   3.12 KB |
| Compiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 | 1,134.949 us |  6.3422 us |  5.6222 us | 1.9531 |      - |     - |  12.69 KB |
|   Normal |  LegacyJitX86 | LegacyJit |      X86 |         net48 |     2.380 us |  0.0472 us |  0.0505 us | 0.7172 |      - |     - |   2.94 KB |
| Compiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 |   631.919 us |  9.4512 us |  8.8406 us | 1.9531 | 0.9766 |     - |   9.41 KB |
|   Normal |     RyuJitX64 |    RyuJit |      X64 |         net48 |     2.076 us |  0.0144 us |  0.0112 us | 1.1139 |      - |     - |   4.57 KB |
| Compiled |     RyuJitX64 |    RyuJit |      X64 |         net48 | 1,167.988 us | 22.9845 us | 34.4021 us | 1.9531 |      - |     - |  14.37 KB |

### 1,000

|   Method |           Job |       Jit | Platform |     Toolchain |       Mean |    Error |    StdDev |     Median |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------- |-------------- |---------- |--------- |-------------- |-----------:|---------:|----------:|-----------:|--------:|-------:|------:|----------:|
|   Normal | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 |   174.0 us |  3.47 us |   7.61 us |   171.0 us | 50.2930 |      - |     - | 206.04 KB |
| Compiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 | 2,039.4 us | 40.86 us | 114.59 us | 2,038.8 us | 52.7344 | 1.9531 |     - | 215.63 KB |
|   Normal |  LegacyJitX86 | LegacyJit |      X86 |         net48 |   282.0 us | 10.30 us |  30.06 us |   269.0 us | 30.2734 |      - |     - | 124.09 KB |
| Compiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 | 1,000.6 us | 20.06 us |  28.12 us |   999.3 us | 31.2500 |      - |     - | 130.78 KB |
|   Normal |     RyuJitX64 |    RyuJit |      X64 |         net48 |   250.2 us |  9.52 us |  27.92 us |   256.2 us | 50.7813 |      - |     - | 208.09 KB |
| Compiled |     RyuJitX64 |    RyuJit |      X64 |         net48 | 1,361.3 us | 25.39 us |  26.07 us | 1,369.7 us | 52.7344 | 1.9531 |     - | 218.27 KB |

### 100,000

|   Method |           Job |       Jit | Platform |     Toolchain |     Mean |    Error |   StdDev |     Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------- |-------------- |---------- |--------- |-------------- |---------:|---------:|---------:|----------:|--------:|------:|----------:|
|   Normal | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 | 17.08 ms | 0.341 ms | 0.466 ms | 4968.7500 |       - |     - |  19.84 MB |
| Compiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 | 16.94 ms | 0.245 ms | 0.229 ms | 4968.7500 |       - |     - |  19.85 MB |
|   Normal |  LegacyJitX86 | LegacyJit |      X86 |         net48 | 20.29 ms | 0.402 ms | 0.683 ms | 2937.5000 |       - |     - |  11.85 MB |
| Compiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 | 17.47 ms | 0.345 ms | 0.751 ms | 2937.5000 | 31.2500 |     - |  11.85 MB |
|   Normal |     RyuJitX64 |    RyuJit |      X64 |         net48 | 19.45 ms | 0.379 ms | 0.673 ms | 4968.7500 |       - |     - |   19.9 MB |
| Compiled |     RyuJitX64 |    RyuJit |      X64 |         net48 | 16.07 ms | 0.319 ms | 0.777 ms | 4968.7500 |       - |     - |  19.91 MB |

### 1,000,000

|   Method |           Job |       Jit | Platform |     Toolchain |     Mean |   Error |   StdDev |   Median |      Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------- |-------------- |---------- |--------- |-------------- |---------:|--------:|---------:|---------:|-----------:|------:|------:|----------:|
|   Normal | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 | 170.3 ms | 6.86 ms |  8.17 ms | 166.6 ms | 49500.0000 |     - |     - | 198.37 MB |
| Compiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 | 145.0 ms | 2.86 ms |  6.50 ms | 144.0 ms | 49500.0000 |     - |     - | 198.38 MB |
|   Normal |  LegacyJitX86 | LegacyJit |      X86 |         net48 | 203.5 ms | 4.02 ms |  6.60 ms | 202.3 ms | 29333.3333 |     - |     - | 118.43 MB |
| Compiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 | 173.8 ms | 3.36 ms |  4.93 ms | 172.5 ms | 29500.0000 |     - |     - | 118.44 MB |
|   Normal |     RyuJitX64 |    RyuJit |      X64 |         net48 | 207.7 ms | 4.46 ms | 13.07 ms | 203.7 ms | 49666.6667 |     - |     - | 198.95 MB |
| Compiled |     RyuJitX64 |    RyuJit |      X64 |         net48 | 141.9 ms | 1.92 ms |  1.80 ms | 142.2 ms | 49500.0000 |     - |     - | 198.96 MB |
