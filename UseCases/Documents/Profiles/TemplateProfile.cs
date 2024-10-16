using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.UseCases.Documents.Dtos;
using AutoMapper;

namespace ASDP.FinalProject.UseCases.Documents.Profiles
{
    public class TemplateProfile : Profile
    {
        public TemplateProfile()
        {
            CreateMap<Template, TemplateResponse>();
        }
    }
}
