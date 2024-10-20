using ASDP.FinalProject.Dtos.Sigex;
using ASDP.FinalProject.UseCases.Authorization.Dtos;
using MediatR;

namespace ASDP.FinalProject.UseCases.Authorization.Commands
{
    public class AuthUsingNcaRequest : IRequest<AuthDataResponse>
    {
        public string Nonce { get; set; }
        public string Signature { get; set; }
        public bool External { get; set; } = false;
    }
}
