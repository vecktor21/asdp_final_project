using ASDP.FinalProject.UseCases.Signing.Dtos;
using MediatR;

namespace ASDP.FinalProject.UseCases.Documents.Commands
{
    public class GenerateSignDocumentCommand : IRequest<DocumentDto>
    {
        public Guid TemplateId { get; set; }
        public int CreatorUserId { get; set; }
        public int TeamleadId { get; set; }
        public int DirectorId { get; set; }
    }
}
