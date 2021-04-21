namespace GrpcSample

open System
open GrpcSample

type GreeterService() =
    inherit Greeter.GreeterBase()

    override _.SayHello(req, ctx) =
        let resp =
            HelloReply(Message = $"Hello, %s{req.Name}!")

        Threading.Tasks.Task.FromResult(resp)
