using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.DAL.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ASDP.FinalProject.UseCases.Employees.Queries
{
    public class GetPermissionsQueryHadnler : IRequestHandler<GetPermissionsQuery, List<Permission>>
    {
        private AdspContext _context { get;set; }
        public GetPermissionsQueryHadnler(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.GetContext();
        }
        public async Task<List<Permission>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Permissions.ToListAsync();
        }
    }
}
