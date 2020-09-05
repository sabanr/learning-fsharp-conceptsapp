open System
open BasicFunctions

[<EntryPoint>]
let main argv =
    let square x = x * x
    
    let sumOfSquares n =
        [1..n]
        |> List.map square 
        |> List.sum

    let s = sumOfSquares 100

    printfn "%i" s

    0
