using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.UseCases.Employees.Dtos;
using MediatR;

namespace ASDP.FinalProject.UseCases.Employees.Queries
{
    public class GetPositionsQuery :IRequest<List<PositionDto>>
    {
    }
}
