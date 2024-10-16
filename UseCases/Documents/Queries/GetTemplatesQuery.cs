using ASDP.FinalProject.UseCases.Documents.Dtos;
using MediatR;

namespace ASDP.FinalProject.UseCases.Documents.Queries
{
    public class GetTemplatesQuery : IRequest<List<TemplateResponse>>
    {
    }
}
