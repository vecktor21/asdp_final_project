using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.UseCases.Employees.Commands;
using ASDP.FinalProject.UseCases.Employees.Dtos;
using AutoMapper;

namespace ASDP.FinalProject.UseCases.Employees.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Position, PositionDto>()
                .ForMember(x=> x.Permissions,opt=>opt.MapFrom(src=>src.Permissions.Select(x=>x.Permission)));
            CreateMap<Permission, PermissionDto>();
            CreateMap<RegisterEmployeeRequest, Employee>();
        }
    }
}
