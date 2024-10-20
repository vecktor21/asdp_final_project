using ASDP.FinalProject.Dtos.Sigex;
using ASDP.FinalProject.Services;
using MediatR;

namespace ASDP.FinalProject.UseCases.Authorization.Queries
{
    public class GetNonceBlockQueryHandler : IRequestHandler<GetNonceBlockQuery, SigexAuthNonceResponse>
    {
        private readonly SigexApi _sigexApi;

        public GetNonceBlockQueryHandler(SigexApi sigexApi)
        {
            _sigexApi = sigexApi;
        }

        public async Task<SigexAuthNonceResponse> Handle(GetNonceBlockQuery request, CancellationToken cancellationToken)
        {
            var response = await _sigexApi.AuthStep1(new());

            return response.Content;

        }
    }
}
