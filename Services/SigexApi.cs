using Refit;

namespace ASDP.FinalProject.Services
{
    /*public interface SigexApi
    {
        [Post("/api")]
        public Task<ApiResponse<SigexRegisterNewDocumentResponse>> RegisterNewDocument([Body]SigexRegisterNewDocumentRequest data);

        [Post("/api/{id}/data")]
        [Headers("Content-Type: application/octet-stream")]
        public Task<SigexSaveDocumentResponse> SaveDocument([AliasAs("id")] string id, [Body] ByteArrayContent file);

        [Post("/api/{id}")]
        public Task<SigexSignDocumentResponse> SignDocument([AliasAs("id")] string id, [Body] SigexSignDocumentRequest data);

        [Post("/api/{id}/buildDDC")]
        [Headers("Content-Type: application/octet-stream")]
        public Task<SigexGenerateSignedDocumentResponse> GenerateSignedDocument([AliasAs("id")] string id,
            [Body] ByteArrayContent file,
            string? fileName = null,
            string? language = "kk/ru",
            bool? withoutDocumentVisualization = false,
            bool? withoutSignaturesVisualization = false,
            bool? withoutQRCodesInSignaturesVisualization = false);


        [Post("/api/auth")]
        [Headers("Content-Type: application/json")]
        public Task<ApiResponse<SigexAuthNonceResponse>> AuthStep1([Body] SigexAuthNonceRequest data);

        [Post("/api/auth")]
        [Headers("Content-Type: application/json")]
        public Task<ApiResponse<SigexAuthDataResponse>> AuthStep2(SigexAuthStep2Request data);
    }*/
}