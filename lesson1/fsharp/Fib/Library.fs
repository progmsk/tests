module Library

open System

let fib_fast n =
    let rec iterate a b p q n =
        if n = 0 then a
        else if n % 2 = 0 then iterate a b (p * p + q * q) (2I * p * q + q * q) (n / 2)
        else iterate (b * q + a * q + a * p) (b * p + a * q) p q (n - 1)
        
    if n < 0 then raise (ArgumentOutOfRangeException(nameof n))
    iterate 0I 1I 0I 1I n

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