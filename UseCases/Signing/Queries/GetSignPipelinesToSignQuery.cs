using ASDP.FinalProject.UseCases.Signing.Dtos;
using MediatR;

namespace ASDP.FinalProject.UseCases.Signing.Queries
{
    public class GetSignPipelinesToSignQuery : IRequest<List<DocumentToSignDto>>
    {
        public int UserId { get; set; }
    }
}
