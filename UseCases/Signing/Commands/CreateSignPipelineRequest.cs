using CSharpFunctionalExtensions;
using MediatR;

namespace ASDP.FinalProject.UseCases.Signing.Commands
{
    public class CreateSignPipelineRequest : IRequest<Result>
    {
        public Guid TemplateId { get; set; }
        public int UserId { get; set; }
        public string CmsSign { get; set; }
        public IFormFile GeneratedDocument { get; set; }
    }
}
