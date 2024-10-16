using ASDP.FinalProject.DAL.Models;
using MediatR;

namespace ASDP.FinalProject.UseCases.Employees.Queries
{
    public class GetPermissionsQuery :IRequest<List<Permission>>
    {

    }
}
