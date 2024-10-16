using ASDP.FinalProject.Constants;
using ASDP.FinalProject.DAL.Models;

namespace ASDP.FinalProject.UseCases.Employees.Dtos
{
    public class PositionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PositionCode Code { get; set; }
        public List<PermissionDto> Permissions { get; set; }
    }
}
