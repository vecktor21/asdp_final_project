namespace ASDP.FinalProject.Dtos.Sigex
{
    public class SigexSaveDocumentResponse
    {
        public string documentId { get; set; }
        public int signedDataSize { get; set; }
        public List<DigestDto> digests { get; set; }
        public List<EmailNotificationsResponseDto> emailNotifications { get; set; }
        public bool dataArchived {  get; set; }
    }

    public class DigestDto
    {
        public string oid { get; set; }
        public string otherOid { get; set; }
    }

    public class EmailNotificationsResponseDto
    {
        public bool attached { get; set; }
        public string message { get; set; }
    }
}