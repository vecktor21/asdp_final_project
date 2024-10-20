namespace ASDP.FinalProject.Dtos.Sigex
{
    public class SigexSaveDocumentResponse: SigexResponse
    {
        public string DocumentId { get; set; }
        public int SignedDataSize { get; set; }
        public List<DigestDto> Digests { get; set; }
        public List<EmailNotificationsResponseDto> EmailNotifications { get; set; }
        public bool DataArchived {  get; set; }
    }

    public class DigestDto
    {
        public string Oid { get; set; }
        public string OtherOid { get; set; }
    }

    public class EmailNotificationsResponseDto
    {
        public bool Attached { get; set; }
        public string Message { get; set; }
    }
}