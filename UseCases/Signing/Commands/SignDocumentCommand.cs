using CSharpFunctionalExtensions;
using MediatR;

namespace ASDP.FinalProject.UseCases.Signing.Commands
{
    public class SignDocumentCommand : IRequest<Result>
    {
        public Guid SignPipelineId { get; set; }
        public int CreatorUserId { get; set; }
        public bool IsSign {  get; set; }
    }
}
