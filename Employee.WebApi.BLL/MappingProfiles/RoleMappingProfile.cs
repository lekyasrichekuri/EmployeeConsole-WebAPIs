using AutoMapper;
using Employee.WebApi.BLL.DataTransferObjects;
using EmployeeConsole_WebAPIs.EmployeeConsole.Models.Model;

namespace EmployeeWebApi.BLL.MappingProfiles
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<RoleDTO, Role>()
                .ForMember(des => des.LocationName, opt => opt.MapFrom(src => src.LocationId))
                .ForMember(des => des.Department, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(des => des.RoleDescription, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();
        }
    }
}
