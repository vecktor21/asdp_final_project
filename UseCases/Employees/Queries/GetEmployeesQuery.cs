using ASDP.FinalProject.Constants;
using ASDP.FinalProject.UseCases.Employees.Dtos;
using MediatR;

namespace ASDP.FinalProject.UseCases.Employees.Queries
{
    public class GetEmployeesQuery : IRequest<List<EmployeeDto>>
    {
        public PositionCode? Position { get; set; }
        
    }
}
