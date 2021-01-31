``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.746 (2004/?/20H1)
Intel Core i7-3520M CPU 2.90GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.101
  [Host]     : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT
  DefaultJob : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT


```
|                    Method |      Mean |    Error |   StdDev |
|-------------------------- |----------:|---------:|---------:|
|    RecursiveFactorialMask |  31.93 ns | 0.143 ns | 0.127 ns |
| NonRecursiveFactorialMask | 182.68 ns | 1.849 ns | 1.639 ns |
