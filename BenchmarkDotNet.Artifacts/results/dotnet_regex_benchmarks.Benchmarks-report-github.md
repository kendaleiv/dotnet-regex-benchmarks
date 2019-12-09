``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18362
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.100
  [Host]        : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  .NET Core x64 : .NET Core 3.1.0 (CoreCLR 4.700.19.56402, CoreFX 4.700.19.56404), X64 RyuJIT
  LegacyJitX86  : .NET Framework 4.8 (4.8.4042.0), X86 LegacyJIT
  RyuJitX64     : .NET Framework 4.8 (4.8.4042.0), X64 RyuJIT


```
|                      Method |           Job |       Jit | Platform |     Toolchain |           Mean |         Error |        StdDev |         Median |      Gen 0 |  Gen 1 | Gen 2 |    Allocated |
|---------------------------- |-------------- |---------- |--------- |-------------- |---------------:|--------------:|--------------:|---------------:|-----------:|-------:|------:|-------------:|
|            RegexSingleMatch | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 |       1.806 us |     0.0344 us |     0.0396 us |       1.799 us |     0.7629 |      - |     - |      3.12 KB |
|    RegexSingleMatchCompiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 |   1,133.686 us |     7.7368 us |     6.4606 us |   1,133.206 us |     1.9531 |      - |     - |     12.69 KB |
|            Regex1000Matches | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 |     172.615 us |     3.4378 us |     4.4701 us |     171.854 us |    50.2930 |      - |     - |    206.04 KB |
|    Regex1000MatchesCompiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 |   1,340.936 us |     9.9735 us |     8.8412 us |   1,342.594 us |    52.7344 | 1.9531 |     - |    215.63 KB |
|         Regex1000000Matches | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 | 162,271.220 us | 3,206.7578 us | 3,938.1866 us | 159,861.975 us | 49500.0000 |      - |     - | 203127.91 KB |
| Regex1000000MatchesCompiled | .NET Core x64 |    RyuJit |      X64 | .NET Core x64 | 136,722.067 us | 2,073.6865 us | 1,939.7276 us | 136,142.750 us | 49500.0000 |      - |     - | 203137.72 KB |
|            RegexSingleMatch |  LegacyJitX86 | LegacyJit |      X86 |         net48 |       2.173 us |     0.0105 us |     0.0093 us |       2.175 us |     0.7172 |      - |     - |      2.94 KB |
|    RegexSingleMatchCompiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 |     610.704 us |     3.6475 us |     3.2334 us |     611.085 us |     1.9531 | 0.9766 |     - |      9.41 KB |
|            Regex1000Matches |  LegacyJitX86 | LegacyJit |      X86 |         net48 |     202.838 us |     3.7654 us |     3.8668 us |     203.856 us |    30.2734 |      - |     - |    124.09 KB |
|    Regex1000MatchesCompiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 |     774.141 us |     3.3989 us |     3.0130 us |     774.722 us |    31.2500 | 0.9766 |     - |    130.78 KB |
|         Regex1000000Matches |  LegacyJitX86 | LegacyJit |      X86 |         net48 | 200,457.185 us | 3,861.2395 us | 3,792.2535 us | 201,898.683 us | 29333.3333 |      - |     - | 121276.94 KB |
| Regex1000000MatchesCompiled |  LegacyJitX86 | LegacyJit |      X86 |         net48 | 161,791.087 us | 3,133.9057 us | 3,483.3279 us | 160,274.675 us | 29500.0000 |      - |     - | 121282.28 KB |
|            RegexSingleMatch |     RyuJitX64 |    RyuJit |      X64 |         net48 |       2.066 us |     0.0397 us |     0.0389 us |       2.052 us |     1.1139 |      - |     - |      4.57 KB |
|    RegexSingleMatchCompiled |     RyuJitX64 |    RyuJit |      X64 |         net48 |   1,145.214 us |    13.8008 us |    12.9093 us |   1,146.898 us |     1.9531 |      - |     - |     14.37 KB |
|            Regex1000Matches |     RyuJitX64 |    RyuJit |      X64 |         net48 |     193.369 us |     3.7252 us |     4.9730 us |     194.446 us |    50.7813 |      - |     - |    208.09 KB |
|    Regex1000MatchesCompiled |     RyuJitX64 |    RyuJit |      X64 |         net48 |   1,322.872 us |     9.5502 us |     7.9748 us |   1,321.787 us |    52.7344 | 1.9531 |     - |    218.27 KB |
|         Regex1000000Matches |     RyuJitX64 |    RyuJit |      X64 |         net48 | 187,093.884 us | 3,222.4216 us | 3,014.2552 us | 186,185.467 us | 49666.6667 |      - |     - | 203728.15 KB |
| Regex1000000MatchesCompiled |     RyuJitX64 |    RyuJit |      X64 |         net48 | 138,939.505 us | 2,122.0352 us | 1,984.9531 us | 138,012.050 us | 49500.0000 |      - |     - | 203738.75 KB |
