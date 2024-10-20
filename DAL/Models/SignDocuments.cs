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
        public string SigexDocumentId { get; set; }

        public SignDocument(byte[] content, string name, SignPipeline signPipeline, string sigexDocumentId)
        {
            this.Content = content;
            this.Name = name;
            this.Id = Guid.NewGuid();
            this.SignPipeline = signPipeline;
            this.SignPipelineId = Guid.NewGuid();
            this.SigexDocumentId = sigexDocumentId;
        }

        public SignDocument()
        {
            
        }
    }
}
