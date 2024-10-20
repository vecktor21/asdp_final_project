using ASDP.FinalProject.Dtos.Sigex;
using MediatR;

namespace ASDP.FinalProject.UseCases.Authorization.Queries
{
    public class GetNonceBlockQuery : IRequest<SigexAuthNonceResponse>
    {
    }
}
