using ASDP.FinalProject.Constants;
using ASDP.FinalProject.DAL.Models;

namespace ASDP.FinalProject.Services.TagReplacers
{
    public class ClientPositionTagReplacer : BaseCreatorEmployeeTagReplacer
    {
        public override string Tag { get; } = Tags.EmployeePosition;

        protected override Task<string> FindValue(Employee employee)
        {
            var res = employee.Position.Name;
            return Task.FromResult(res);
        }
    }
}
