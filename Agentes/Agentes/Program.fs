open Logger

#nowarn "40"
let printerAgent = MailboxProcessor.Start(fun inbox -> 
    let rec messageLoop = async {
        let! msg = inbox.Receive()

        printfn "MESSAGE: %s" msg

        return! messageLoop
    }
    
    messageLoop
    )

[<EntryPoint>]
let main argv = 
    printerAgent.Post "teste"
    printerAgent.Post "teste1"
    printerAgent.Post "teste2"
    let serializedLogger = SerializedLogger()
    serializedLogger.Log "hello"

    let s = System.Console.ReadKey()
    0 // return an integer exit code
