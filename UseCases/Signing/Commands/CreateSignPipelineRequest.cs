using CSharpFunctionalExtensions;
using MediatR;

namespace ASDP.FinalProject.UseCases.Signing.Commands
{
    public class CreateSignPipelineRequest : IRequest<Result>
    {
        public int UserId { get; set; }
        public IFormFile GeneratedDocument { get; set; }
        public int TeamleadId { get; set; }
        public int DirectorId { get; set; }
        public string SigexDocumentId { get; set; }
        public long SigexSignId { get; set; }
    }
}
