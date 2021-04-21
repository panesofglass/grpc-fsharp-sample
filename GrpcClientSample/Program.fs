// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open Grpc.Net.Client
open GrpcSample

[<EntryPoint>]
let main argv =
    use channel =
        GrpcChannel.ForAddress("https://localhost:5001/")

    let client = Greeter.GreeterClient(channel)

    let req = HelloRequest(Name = "World")

    let resp = client.SayHello(req)

    printfn "%s" resp.Message
    0
