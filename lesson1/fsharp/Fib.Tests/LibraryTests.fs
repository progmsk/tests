module LibraryTests

open System
open System.Numerics
open Library
open Xunit

[<Theory>]
[<InlineData(0, 1, 2, 3, 3)>]
[<InlineData(3, 2, 2, 3, 21)>]
let ``next_a - parameterised test`` a b p q expected =
    Assert.Equal(expected, next_a a b p q)

[<Theory>]
[<InlineData(0, 1, 2, 3, 2)>]
[<InlineData(3, 2, 2, 3, 13)>]
let ``next_b - parameterised test`` a b p q expected =
    Assert.Equal(expected, next_b a b p q)

[<Theory>]
[<InlineData(0, 1, 1)>]
[<InlineData(1, 1, 2)>]
[<InlineData(2, 3, 13)>]
[<InlineData(13, 21, 610)>]
let ``next_p - parameterised test`` p q expected =
    Assert.Equal(expected, next_p p q)

[<Theory>]
[<InlineData(0, 1, 1)>]
[<InlineData(1, 1, 3)>]
[<InlineData(2, 3, 21)>]
[<InlineData(13, 21, 987)>]
let ``next_q - parameterised test`` p q expected =
    Assert.Equal(expected, next_q p q)
    
[<Fact>]
let ``step - with odd n - decreases n`` () =
    let prev_n = 5
    let (_, _, _, _, n) = step (0I, 1I, 2I, 3I, prev_n)
    Assert.Equal(prev_n - 1, n)
    
[<Fact>]
let ``step - with even n - divides n by 2`` () =
    let prev_n = 6
    let (_, _, _, _, n) = step (1I, 0I, 2I, 3I, prev_n)
    
    Assert.Equal(prev_n / 2, n)
    
[<Fact>]
let ``step - with odd n - changes a and b`` () =
    let n = 5
    let prev_a = 0I
    let prev_b = 1I
    let (a, b, _, _, _) = step (prev_a, prev_b, 2I, 3I, n)
    
    Assert.NotEqual(prev_a, a)
    Assert.NotEqual(prev_b, b)

[<Fact>]
let ``step - with odd n - keeps p and q`` () =
    let n = 5
    let prev_p = 2I
    let prev_q = 3I
    let (_, _, p, q, _) = step (0I, 1I, prev_p, prev_q, n)
    
    Assert.Equal(prev_p, p)
    Assert.Equal(prev_q, q)
    
[<Fact>]
let ``step - with even n - keeps a and b`` () =
    let n = 6
    let prev_a = 0I
    let prev_b = 1I
    let (a, b, _, _, _) = step (prev_a, prev_b, 2I, 3I, n)
    
    Assert.Equal(prev_a, a)
    Assert.Equal(prev_b, b)

[<Fact>]
let ``step - with even n - changes p and q`` () =
    let n = 6
    let prev_p = 2I
    let prev_q = 3I
    let (_, _, p, q, _) = step (0I, 1I, prev_p, prev_q, n)
    
    Assert.NotEqual(prev_p, p)
    Assert.NotEqual(prev_q, q)

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