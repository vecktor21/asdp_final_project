using ASDP.FinalProject.UseCases.Signing.Commands;
using AutoMapper;

namespace ASDP.FinalProject.UseCases.Signing.Profiles
{
    public class SignProfile : Profile
    {
        public SignProfile()
        {
            CreateMap<CreateSignPipelineContract, CreateSignPipelineRequest>();
        }
    }
}
