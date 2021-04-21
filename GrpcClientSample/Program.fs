// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open Grpc.Net.Client
open GrpcSample

[<EntryPoint>]
let main argv =
    use channel =
        GrpcChannel.ForAddress("https://localhost:5001/")

    let client = Greeter.GreeterClient(channel)

    let req =
        { HelloRequest.empty () with
              Name = ValueSome "World" }

    let resp = client.SayHello(req)

    resp.Message
    |> ValueOption.iter (fun msg -> printfn $"%s{msg}")

    0
