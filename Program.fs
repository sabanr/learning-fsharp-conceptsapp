open System

// use records
type SuccessfulWithdrawal = {
    Amount : decimal
    Balance : decimal
}

type FailedWithdrawal = {
    Amount: decimal
    Balance : decimal
    IsOverdraft: bool
}

// use discriminated unions to represent data of 1 or more forms
type WithdrawalResult = 
    |Success of SuccessfulWithdrawal
    |InsufficientFunds of FailedWithdrawal
    |CardExpired of DateTime
    |UndisclosedFailure

let handleWithdrawal amount =
    let withdrawalResult = WithdrawalResult.CardExpired(DateTime.Now)

    match withdrawalResult with
       |Success s -> printfn "Successfully withdrew %f" s.Amount
       |InsufficientFunds f -> printfn "Failed to withdraw %f. Balance is %f" f.Amount f.Balance
       |CardExpired ce -> printfn "The card expired on %O" ce
       |UndisclosedFailure -> printfn "Unknown failure" 

    0

[<EntryPoint>]
let main argv =
    handleWithdrawal 10.0



