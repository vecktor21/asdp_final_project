namespace ASDP.FinalProject.Dtos.Sigex
{
    public class SigexAuthNonceRequest
    {
        
    }
    public class SigexAuthNonceResponse :SigexResponse
    {
        public string Nonce { get; set; }
    }
}
