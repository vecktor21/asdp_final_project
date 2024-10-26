using ASDP.FinalProject.Constants;
using ASDP.FinalProject.DAL.Models;

namespace ASDP.FinalProject.Services.TagReplacers
{
    public class ValidityPeriodWhomAndWhenIssuedTagReplacer : BaseCreatorEmployeeTagReplacer
    {
        public override string Tag { get; } = Tags.ValidityPeriodWhomAndWhenIssued;

        protected override Task<string> FindValue(Employee employee)
        {
            var res = $"{employee.IdentityIssueDate} {employee.IdentityIssuer}";
            return Task.FromResult(res);
        }
    }
}
