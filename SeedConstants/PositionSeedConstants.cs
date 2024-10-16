using ASDP.FinalProject.Constants;
using ASDP.FinalProject.DAL.Models;

namespace ASDP.FinalProject.SeedConstants
{
    public class PositionSeedConstants
    {

        public static Position Employee = new()
        {
            Id = 1,
            Code = PositionCode.Employee,
            Name = "Сотрудник",
            Permissions = new List<Permission>()
        };
        public static Position Teamlead = new()
        {
            Id = 2,
            Code = PositionCode.Teamlid,
            Name = "Тимлид",
            Permissions = new List<Permission> { PermissionSeedConstants.SignDocuments }
        };
        public static Position Director = new()
        {
            Id = 3,
            Code = PositionCode.Director,
            Name = "Директор",
            Permissions = new List<Permission> { PermissionSeedConstants.SignDocuments }
        };
    }
}
