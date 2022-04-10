open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open Library


type BenchmarksTests() =
    [<Params(0, 1, 6, 40)>]
    member val n = 0 with get, set
    
    [<Benchmark>]
    member this.exponential () = fib_slow this.n |> ignore

    [<Benchmark>]
    member this.linear () = fib this.n |> ignore
    

BenchmarkRunner.Run<BenchmarksTests> () |> ignore