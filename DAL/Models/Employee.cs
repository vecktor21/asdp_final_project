namespace ASDP.FinalProject.DAL.Models
{
    public class Employee
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
        public string Password { get; set; } = null!;
        //Pipelines to sign
        public List<SignerToPipeline> PipelinesToSign { get; set; }
        public List<SignPipeline> CreatedSignPipelines { get; set; }

    }
}
