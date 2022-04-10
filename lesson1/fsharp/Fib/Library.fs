module Library

open System

let internal next_a a b p q = b * q + a * q + a * p

let internal next_b a b p q = b * p + a * q

let internal next_p p q = p * p + q * q

let internal next_q p q = 2I * p * q + q * q

let internal step (a, b, p, q, n) =
    if n % 2 = 0 then (a, b, next_p p q, next_q p q, n / 2)
    else (next_a a b p q, next_b a b p q, p, q, n - 1)

let fib_fast n =
    let rec iterate (a, b, p, q, n) =
        if n = 0 then a
        else (a, b, p, q, n) |> step |> iterate
        
    if n < 0 then raise (ArgumentOutOfRangeException(nameof n))
    iterate (0I, 1I, 0I, 1I, n)

let fib n =
    let rec iterate a b n =
        if n = 0 then a
        else iterate b (a + b) (n - 1)

    if n < 0 then raise (ArgumentOutOfRangeException(nameof n))
    iterate 0I 1I n

let rec fib_slow n =
    if n < 0 then raise (ArgumentOutOfRangeException(nameof n))
    
    if n = 0 then 0I
    else if n = 1 then 1I
    else fib_slow (n - 1) + fib_slow (n - 2)