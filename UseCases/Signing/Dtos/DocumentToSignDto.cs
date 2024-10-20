using ASDP.FinalProject.Constants;

namespace ASDP.FinalProject.UseCases.Signing.Dtos
{
    public class DocumentToSignDto
    {
        public Guid DocumentId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public SignPipelineStatus StatusCode { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}