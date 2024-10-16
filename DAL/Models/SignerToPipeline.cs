namespace ASDP.FinalProject.DAL.Models
{
    public class SignerToPipeline
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public Guid SignPipelineId { get; set; }
        public SignPipeline SignPipeline { get; set; }
        public int SignerEmployeeId { get; set; }
        public Employee SignerEmployee { get; set; }
        public bool IsSigned { get; set; }
    }
}
