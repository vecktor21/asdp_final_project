using ASDP.FinalProject.Constants;

namespace ASDP.FinalProject.UseCases.Signing.Dtos
{
    public class DocumentToSignDto
    {
        public Guid SignPipelineId { get; set; }
        public Guid DocumentId { get; set; }
        public string SigexDocumentId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public SignPipelineStatus StatusCode { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}