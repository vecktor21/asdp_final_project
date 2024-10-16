using ASDP.FinalProject.Constants;

namespace ASDP.FinalProject.DAL.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public PermissionCodes Code { get; set; }
    }
}
