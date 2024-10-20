using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.DAL.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ASDP.FinalProject.UseCases.Documents.Queries
{
    public class GetDocumentQueryHandler : IRequestHandler<GetDocumentQuery, SignDocument>
    {
        private AdspContext _context;
        public GetDocumentQueryHandler(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.GetContext();
        }
        public async Task<SignDocument> Handle(GetDocumentQuery request, CancellationToken cancellationToken)
        {
            var fileDb = await _context.SignDocuments.Where(x=> x.Id == request.DocumentId).SingleAsync();

            return fileDb;
        }
    }
}
