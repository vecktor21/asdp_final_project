using static ASDP.FinalProject.Dtos.Sigex.SigexRegisterNewDocumentRequest;

namespace ASDP.FinalProject.Dtos.Sigex
{
    public class SigexRegisterNewDocumentRequest
    {
        public string title { get; set; }
        public string description { get; set; }
        public string signType { get; set; } = "cms";
        public string signature { get; set; } = null!;
        public SigexEmailNotifications emailNotifications { get; set; } = new();
        public SigexDocumentSettingsDto settings { get; set; } = new();


    }
    public class SigexRegisterNewDocumentResponse
    {
        public string documentId { get; set; }
        public int signId { get; set; }
        public string data { get; set; }
    }
}
