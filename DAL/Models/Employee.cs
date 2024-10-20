namespace ASDP.FinalProject.DAL.Models
{
    public class Employee
    {
        public int Id { get; protected set; }
        public int PositionId { get; protected set; }
        public Position Position { get; protected set; }
        public string Mail { get; protected set; } = null!;
        public string Name { get; protected set; } = null!;
        public string SurName { get; protected set; } = null!;
        public string Iin { get; protected set; } = null!;
        public string IdentityNumber { get; protected set; } = null!;
        public string IdentityIssuer { get; protected set; } = null!;
        public DateTime IdentityIssueDate { get; protected set; }
        public List<SignerToPipeline> PipelinesToSign { get; protected set; }
        public List<SignPipeline> CreatedSignPipelines { get; protected set; }

        public Employee(string name, string surName, string iin, string mail, string identityNumber,
            string identityIssuer, DateTime identityIssueDate, Position position)
        {
            Name = name;
            SurName = surName;
            Iin = iin;
            Mail = mail;
            IdentityNumber = identityNumber;
            IdentityIssuer = identityIssuer;
            IdentityIssueDate = identityIssueDate;
            Position = position;
            PositionId = position.Id;
            this.PipelinesToSign = new();
            this.CreatedSignPipelines = new();
        }

        public Employee()
        {
            
        }

    }
}
