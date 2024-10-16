using ASDP.FinalProject.Constants;
using ASDP.FinalProject.DAL.Configs;
using ASDP.FinalProject.DAL.Models;

namespace ASDP.FinalProject.DAL.SeedConstants
{
    public class PositionSeedConstants
    {

        public static Position Employee = new()
        {
            Id = 1,
            Code = PositionCode.Employee,
            Name = "Сотрудник"
        };
        public static Position Teamlead = new()
        {
            Id = 2,
            Code = PositionCode.Teamlid,
            Name = "Тимлид"
        };
        public static Position Director = new()
        {
            Id = 3,
            Code = PositionCode.Director,
            Name = "Директор"
        };

        public static List<Position> All = new List<Position>
        {
            Employee, Teamlead, Director
        };

        public static List<PositionPermission> AllPermissionPositions = new List<PositionPermission>
        {
            new (){ Id = 1, PositionId = 2, PermissionId = 1 }, // Teamlead -> SignDocuments
            new (){ Id = 2, PositionId = 3, PermissionId = 1 }  // Director -> SignDocuments
        };
    }
}
