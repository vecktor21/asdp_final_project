using ASDP.FinalProject.Constants;

namespace ASDP.FinalProject.DAL.Models
{
    public class SignPipeline
    {
        public Guid Id { get; set; }
        public int CreatorEmployeeId { get; set; }
        public Employee CreatorEmployee { get; set; }
        public SignPipelineStatus Status { get; set; }
        public Guid SignDocumentId { get; set; }
        public SignDocument SignDocument { get; set; }
        public List<SignerToPipeline> Signers { get; set; }
    }
}
