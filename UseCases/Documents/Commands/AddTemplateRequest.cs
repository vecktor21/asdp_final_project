using CSharpFunctionalExtensions;
using MediatR;

namespace ASDP.FinalProject.UseCases.Documents.Commands
{
    public class AddTemplateRequest : IRequest<Result>
    {
        public string Name { get; set; }
        public byte[] Content { get; set; } 
        public string ContentType { get; set; }
    }
}
