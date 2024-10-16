using ASDP.FinalProject.Constants;
using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.UseCases.Employees.Dtos;
using MediatR;

namespace ASDP.FinalProject.UseCases.Employees.Commands
{
    public class RegisterEmployeeRequest : IRequest<EmployeeDto>
    {
        public PositionCode PositionCode{ get; set; }
        public string Mail { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string Iin { get; set; } = null!;
        public string IdentityNumber { get; set; } = null!;
        public string IdentityIssuer { get; set; } = null!;
        public DateTime IdentityIssueDate { get; set; }
        public string Password { get; set; } = null!;
        public string RepeatPassword { get; set; } = null!;
    }
}
