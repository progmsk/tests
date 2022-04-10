module Library

open System

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