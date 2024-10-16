namespace ASDP.FinalProject.DAL.Models
{
    public class SignDocument
    {
        public Guid Id { get; set; }
        public Guid SignPipelineId { get; set; }
        public SignPipeline SignPipeline { get; set; }
        public byte[] Content { get; set; }
        public DateTimeOffset IndexDate { get; set; } = DateTimeOffset.Now;
        public string Name { get; set; }
    }
}
