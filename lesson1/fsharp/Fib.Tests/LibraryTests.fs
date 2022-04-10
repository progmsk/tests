module LibraryTests

open System
open System.Numerics
open Library
open Xunit

[<Theory>]
[<InlineData(0, "0")>]
[<InlineData(1, "1")>]
[<InlineData(6, "8")>]
[<InlineData(40, "102334155")>]
let ``fib_fast - parameterised test`` n expected =
    Assert.Equal(BigInteger.Parse expected, fib_fast n)

[<Fact>]
let ``fib_fast - with -1 - throws ArgumentOutOfRangeException`` () =
    Assert.Throws<ArgumentOutOfRangeException> (fun () -> fib_fast -1 |> ignore) 

[<Theory>]
[<InlineData(0, "0")>]
[<InlineData(1, "1")>]
[<InlineData(6, "8")>]
[<InlineData(40, "102334155")>]
let ``fib - parameterised test`` n expected =
    Assert.Equal(BigInteger.Parse expected, fib n)

[<Fact>]
let ``fib - with -1 - throws ArgumentOutOfRangeException`` () =
    Assert.Throws<ArgumentOutOfRangeException> (fun () -> fib -1 |> ignore) 

[<Theory>]
[<InlineData(0, "0")>]
[<InlineData(1, "1")>]
[<InlineData(6, "8")>]
let ``fib_slow - parameterised test`` n expected =
    Assert.Equal(BigInteger.Parse expected, fib_slow n)

[<Fact>]
let ``fib_slow - with -1 - throws ArgumentOutOfRangeException`` () =
    Assert.Throws<ArgumentOutOfRangeException> (fun () -> fib_slow -1 |> ignore) 