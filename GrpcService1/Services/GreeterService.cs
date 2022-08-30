using AttestService1;
using Grpc.Core;

namespace GrpcService1.Services
{
    public class AttestService : CMAA.CMAABase
    {
        private readonly ILogger<AttestService> _logger;
        public AttestService(ILogger<AttestService> logger)
        {
            _logger = logger;
        }

        public override Task<AttestReply> Attest(AttestRequest request, ServerCallContext context)
        {
            return Task.FromResult(new AttestReply
            {
                Token = "Successfully got token for TEE " + request.Tee + " from AttestService"
            });
        }
    }
}