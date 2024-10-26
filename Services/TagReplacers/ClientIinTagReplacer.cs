using ASDP.FinalProject.Constants;
using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.DAL.Repositories;

namespace ASDP.FinalProject.Services.TagReplacers
{
    public class ClientIinTagReplacer : BaseCreatorEmployeeTagReplacer
    {
        public ClientIinTagReplacer(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public override string Tag { get; } = Tags.EmployeeIIN;
        public ClientIinTagReplacer()
        {
            
        }

        protected override Task<string> FindValue(Employee employeeCreator)
        {
            var employeeIin = employeeCreator.Iin;
            return Task.FromResult(employeeIin);
        }
    }
}
