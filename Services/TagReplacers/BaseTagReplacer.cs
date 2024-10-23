using ASDP.FinalProject.Constants;
using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ASDP.FinalProject.Services.TagReplacers
{
    public abstract class BaseCreatorEmployeeTagReplacer : ITagReplacer
    {
        protected readonly AdspContext _context;
        public BaseCreatorEmployeeTagReplacer(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.GetContext();
        }
        protected BaseCreatorEmployeeTagReplacer()
        {
            
        }
        public abstract string Tag { get; }

        public async Task<string> FindTagValue(SignContext signContext)
        {
            var employeeCreator = await _context.Employees.Include(x => x.Position.Permissions)
                .SingleAsync(x => x.Id == signContext.creatorEmployeeId);
            return await FindValue(employeeCreator);
        }

        protected abstract Task<string> FindValue(Employee employee);
    }
}
