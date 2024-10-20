namespace ASDP.FinalProject.Dtos.Sigex
{
    public class SigexSignDocumentRequest
    {
        public string signType { get; set; }
        public string signature { get; set; }
        public List<SigexEmailNotifications> signatureEmailNotifications { get; set; }
    }

    public class SigexSignDocumentResponse: SigexResponse
    {
        public string documentId { get; set; }
        public int signId { get; set; }
        public string data {  get; set; }
        public bool dataArchived { get; set; }
        public bool canBeArchived { get; set; }
        //public string data { get; set; }
    }
}
