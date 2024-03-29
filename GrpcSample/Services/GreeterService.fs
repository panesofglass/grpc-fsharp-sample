namespace GrpcSample

open System

type GreeterService() =
    inherit GrpcSample.Greeter.GreeterBase()

    override _.SayHello req ctx =
        let resp =
            { HelloReply.empty() with
                // Notice how we're immediately forced to handle missing fields.
                // The language itself protects you from the binary protocol's quirks.
                // How cool is THAT?
                Message = req.Name |> ValueOption.map (sprintf "Hello, %s!")
            }
        Threading.Tasks.Task.FromResult(resp)