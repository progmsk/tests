open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open Library


type BenchmarksTests() =
    [<Benchmark>]
    [<Arguments(0)>]
    [<Arguments(1)>]
    [<Arguments(6)>]
    [<Arguments(40)>]
    member this.exponential n = fib_slow n |> ignore

    [<Benchmark>]
    [<Arguments(0)>]
    [<Arguments(1)>]
    [<Arguments(6)>]
    [<Arguments(40)>]
    [<Arguments(100)>]
    [<Arguments(1000)>]
    member this.linear n = fib n |> ignore
    
    [<Benchmark>]
    [<Arguments(40)>]
    [<Arguments(100)>]
    [<Arguments(1000)>]
    member this.logarithm n = fib_fast n |> ignore
    

BenchmarkRunner.Run<BenchmarksTests> () |> ignore