using ASDP.FinalProject.Constants;
using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.Helpers;
using ASDP.FinalProject.UseCases.Signing.Commands;
using ASDP.FinalProject.UseCases.Signing.Dtos;
using AutoMapper;

namespace ASDP.FinalProject.UseCases.Signing.Profiles
{
    public class SignProfile : Profile
    {
        public SignProfile()
        {
            CreateMap<SignPipeline, DocumentToSignDto>()
                .ForMember(x => x.Status, opt => opt.MapFrom(src => EnumHelper<SignPipelineStatus>.GetDisplayValue(src.Status)))
                .ForMember(x => x.StatusCode, opt => opt.MapFrom(src => src.Status))
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => src.SignDocument.IndexDate))
                .ForMember(x => x.DocumentId, opt => opt.MapFrom(src => src.SignDocumentId))
                .ForMember(x => x.SignPipelineId, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.SignDocument.Name))
                .ForMember(x => x.SigexDocumentId, opt => opt.MapFrom(src => src.SignDocument.SigexDocumentId));
        }
    }
}
