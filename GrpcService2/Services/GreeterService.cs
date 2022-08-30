using AttestService1;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcService2;

namespace GrpcService2.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            if(request.Name == "callAttest")
            {
                var channel = GrpcChannel.ForAddress("http://20.12.255.1:80");
                var client = new CMAA.CMAAClient(channel);
                var reply = client.Attest(new AttestRequest { Tee = "SevSnp" });
                return Task.FromResult(new HelloReply
                {
                    Message = "Requested " + request.Name + ": " + reply.Token
                });
            }
            return Task.FromResult(new HelloReply
            {
                Message = "Calling " + request.Name
            });
        }
    }
}