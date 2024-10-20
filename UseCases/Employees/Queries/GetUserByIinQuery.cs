using ASDP.FinalProject.UseCases.Employees.Dtos;
using MediatR;

namespace ASDP.FinalProject.UseCases.Employees.Queries
{
    public class GetEmployeeByIinQuery : IRequest<EmployeeDto?>
    {
        public string Iin { get; set; }
    }
}
