using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.DAL.Repositories;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ASDP.FinalProject.UseCases.Documents.Commands
{
    public class AddTemplateRequestHandler : IRequestHandler<AddTemplateRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AdspContext _context;

        public AddTemplateRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = unitOfWork.GetContext();
        }
        public async Task<Result> Handle(AddTemplateRequest request, CancellationToken cancellationToken)
        {
            var existingTemplate = await _context.Templates.FirstOrDefaultAsync(x => x.Name == request.Name);
            if (existingTemplate != null)
            {
                _context.Remove(existingTemplate);
            }

            var template = new Template(request.Content, request.Name);
            _context.Templates.Add(template);

            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}
