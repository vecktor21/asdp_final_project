using ASDP.FinalProject.Dtos.Sigex;
using ASDP.FinalProject.Services;
using ASDP.FinalProject.UseCases.Authorization.Dtos;
using AutoMapper;
using MediatR;

namespace ASDP.FinalProject.UseCases.Authorization.Commands
{
    public class AuthUsingNcaRequestHandler : IRequestHandler<AuthUsingNcaRequest, AuthDataResponse>
    {
        private readonly SigexApi _sigexApi;
        private readonly IMapper _mapper;

        public AuthUsingNcaRequestHandler(SigexApi sigexApi,IMapper mapper)
        {
            _sigexApi = sigexApi;
            _mapper = mapper;
        }

        public async Task<AuthDataResponse> Handle(AuthUsingNcaRequest request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<SigexAuthStep2Request>(request);
            var response = await _sigexApi.AuthStep2(data);
            var cookies = response.Headers.GetValues("Set-Cookie");
            var authData = _mapper.Map<AuthDataResponse>(response.Content);

            var jwtToken = cookies.First().Split(";").First(x=> x.StartsWith("jwt="))
                .Substring(4);

            authData.Token = jwtToken;
            return authData;
        }
    }
}
