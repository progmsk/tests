module Library

open System

let rec fib n =
    if n < 0 then raise (ArgumentOutOfRangeException(nameof n))
    
    if n = 0 then 0I
    else if n = 1 then 1I
    else fib (n - 1) + fib (n - 2)