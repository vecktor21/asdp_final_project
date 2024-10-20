using ASDP.FinalProject.Dtos.Sigex;
using ASDP.FinalProject.Services;
using ASDP.FinalProject.UseCases.Authorization.Dtos;
using AutoMapper;
using MediatR;

namespace ASDP.FinalProject.UseCases.Authorization.Commands
{
    public class AuthUsingNcaRequestHandler : IRequestHandler<AuthUsingNcaRequest, AuthDataResponse>
    {
        private readonly IMapper _mapper;

        public AuthUsingNcaRequestHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<AuthDataResponse> Handle(AuthUsingNcaRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
