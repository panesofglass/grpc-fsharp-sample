// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open Grpc.Net.Client

[<EntryPoint>]
let main argv =
    use channel =
        GrpcChannel.ForAddress("https://localhost:5001/")

    let client =
        Greet.GreeterService.GreeterServiceClient(channel)

    let req =
        { Greet.HelloRequest.empty () with
              Name = ValueSome "World" }

    let resp =
        client.SayHello(req).ResponseAsync.Result

    printfn "%s" resp.Message
    0
