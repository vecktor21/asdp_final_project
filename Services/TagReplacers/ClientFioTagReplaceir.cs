using ASDP.FinalProject.Constants;
using ASDP.FinalProject.DAL.Models;

namespace ASDP.FinalProject.Services.TagReplacers
{
    public class ClientFioTagReplacer : BaseCreatorEmployeeTagReplacer
    {
        public override string Tag { get; } = Tags.EmployeeFIO;

        protected override Task<string> FindValue(Employee employee)
        {
            var fio = $"{employee.SurName} {employee.Name}";
            return Task.FromResult(fio);
        }
    }
}
