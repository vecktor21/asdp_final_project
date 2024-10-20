using ASDP.FinalProject.Dtos.Sigex;
using ASDP.FinalProject.UseCases.Authorization.Commands;
using ASDP.FinalProject.UseCases.Authorization.Dtos;
using AutoMapper;

namespace ASDP.FinalProject.UseCases.Authorization.Profiles
{
    public class AuthUsingNcaProfile : Profile
    {
        public AuthUsingNcaProfile()
        {
            CreateMap<AuthUsingNcaRequest, SigexAuthStep2Request>();
            CreateMap<SigexAuthDataResponse, AuthDataResponse>();
        }
    }
}
