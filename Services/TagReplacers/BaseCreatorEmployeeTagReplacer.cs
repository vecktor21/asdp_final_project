using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.DAL.Repositories;

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
            return await FindValue(signContext.creatorEmployee);
        }

        protected abstract Task<string> FindValue(Employee employee);
    }
}
