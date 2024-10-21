using ASDP.FinalProject.DAL.Models;
using MediatR;

namespace ASDP.FinalProject.UseCases.Documents.Queries
{
    public class GetTemplateQuery : IRequest<Template>
    {
        public Guid TemplateId { get; set; }
    }
}
