using ASDP.FinalProject.Constants;
using ASDP.FinalProject.DAL.Models;

namespace ASDP.FinalProject.SeedConstants
{
    public static class PermissionSeedConstants
    {
        public static Permission SignDocuments = new Permission
        {
            Id = 1,
            Code = PermissionCodes.SignDocuments,
            Name = "Подпись документов",
        };

        public static List<Permission> All = new List<Permission>()
        {
            SignDocuments
        };
    }
}
