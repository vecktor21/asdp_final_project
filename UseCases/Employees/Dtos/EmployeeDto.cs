using ASDP.FinalProject.DAL.Models;

namespace ASDP.FinalProject.UseCases.Employees.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public string Mail { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string Iin { get; set; } = null!;
        public string IdentityNumber { get; set; } = null!;
        public string IdentityIssuer { get; set; } = null!;
        public DateTime IdentityIssueDate { get; set; }
    }
}
