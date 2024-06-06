using AutoMapper;
using Employee.WebApi.Models.DataTransferObjects;
using EmployeeConsole_WebAPIs.Employee.WebApi.Models.Models;

namespace Employee.WebApi.BLL.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<DepartmentDTO, Department>()
                .ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => src.DepartmentName))
                .ReverseMap();
            CreateMap<EmployeeDTO, Employeee>()
                //.ForMember(des => des.RoleDepartmentLocation.RoleId, opt => opt.MapFrom(src => src.JobTitle ))
                //.ForMember(des => des.RoleDepartmentLocation.DepartmentId, opt => opt.MapFrom(src => src.Department))
                //.ForMember(des => des.RoleDepartmentLocation.LocationId, opt => opt.MapFrom(src => src.Location))
                .ReverseMap();
            CreateMap<LocationDTO, Location>()
                .ForMember(des => des.LocationName, opt => opt.MapFrom(src => src.LocationName))
                .ReverseMap();
            CreateMap<ProjectDTO, Project>()
                .ForMember(des => des.ProjectName, opt => opt.MapFrom(src => src.ProjectName))
                .ReverseMap();
            CreateMap<RoleDTO, Role>()
                .ForMember(des => des.RoleDepartmentLocations, opt => opt.MapFrom(src => new List<RoleDepartmentLocation>
                {
                    new RoleDepartmentLocation
                    {
                        DepartmentId = src.DepartmentId,
                        LocationId = src.LocationId,
                        RoleDescription = src.RoleDescription,
                        IsDeleted = src.IsDeleted
                    }
                }))
                .ReverseMap();
            CreateMap<StatusDTO, Status>()
                .ForMember(des => des.StatusName, opt => opt.MapFrom(src => src.StatusName))
                .ReverseMap();
        }
    }
}
