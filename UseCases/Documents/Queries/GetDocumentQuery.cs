using ASDP.FinalProject.DAL.Models;
using MediatR;

namespace ASDP.FinalProject.UseCases.Documents.Queries
{
    public class GetDocumentQuery : IRequest<SignDocument>
    {
        public Guid DocumentId { get; set; }
    }
}
