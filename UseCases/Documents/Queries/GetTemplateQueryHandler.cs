using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.DAL.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ASDP.FinalProject.UseCases.Documents.Queries
{
    public class GetTemplateQueryHandler : IRequestHandler<GetTemplateQuery, Template>
    {
        private AdspContext _context;
        public GetTemplateQueryHandler(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.GetContext();
        }
        public async Task<Template> Handle(GetTemplateQuery request, CancellationToken cancellationToken)
        {
            var fileDb = await _context.Templates.Where(x => x.Id == request.TemplateId).SingleAsync();
            return fileDb;
        }
    }
}
