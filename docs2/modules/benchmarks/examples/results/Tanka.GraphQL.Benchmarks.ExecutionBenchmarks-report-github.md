``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.19041
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.300-preview-015048
  [Host] : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT

Toolchain=InProcessEmitToolchain  

```
|                                Method | ExecutionCount |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |--------------- |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|           Mutation_without_validation |              1 |  4.836 us | 0.1774 us | 0.5119 us |  4.669 us |  0.93 |    0.12 | 0.8240 |     - |     - |   3.37 KB |
|              Query_without_validation |              1 |  5.206 us | 0.1385 us | 0.4018 us |  4.994 us |  1.00 |    0.00 | 0.9308 |     - |     - |   3.83 KB |
|          Subscribe_without_validation |              1 | 13.349 us | 0.3105 us | 0.9155 us | 13.252 us |  2.58 |    0.22 | 2.1057 |     - |     - |   8.58 KB |
|                Mutation_with_defaults |              1 | 21.504 us | 0.4605 us | 1.3359 us | 21.429 us |  4.15 |    0.41 | 4.9133 |     - |     - |  20.11 KB |
|                   Query_with_defaults |              1 | 23.582 us | 0.2700 us | 0.2525 us | 23.606 us |  4.08 |    0.16 | 5.0354 |     - |     - |  20.57 KB |
|               Subscribe_with_defaults |              1 | 31.834 us | 0.4917 us | 0.4359 us | 31.748 us |  5.51 |    0.25 | 6.3477 |     - |     - |  25.92 KB |
| Subscribe_with_defaults_and_get_value |              1 | 32.444 us | 0.3774 us | 0.3346 us | 32.455 us |  5.61 |    0.23 | 6.3477 |     - |     - |  25.92 KB |
