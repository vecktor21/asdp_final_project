using ASDP.FinalProject.Constants;

namespace ASDP.FinalProject.UseCases.Employees.Dtos
{
    public class PermissionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public PermissionCodes Code { get; set; }
    }
}
