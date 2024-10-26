using ASDP.FinalProject.Constants;
using ASDP.FinalProject.DAL.Models;

namespace ASDP.FinalProject.Services.TagReplacers
{
    public class EmployeeDocumentNumberTagReplacer : BaseCreatorEmployeeTagReplacer
    {
        public override string Tag { get; } = Tags.EmployeeDocumentNumber;

        protected override Task<string> FindValue(Employee employee)
        {
            var res = employee.IdentityNumber;
            return Task.FromResult(res);
        }
    }
}
