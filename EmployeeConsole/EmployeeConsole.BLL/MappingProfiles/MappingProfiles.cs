using AutoMapper;
using Employee.WebApi.Models.DataTransferObjects;
using EmployeeConsole_WebAPIs.EmployeeConsole.Models.Models;
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
               .ForMember(des => des.StatusId, opt => opt.MapFrom(src => src.StatusId))
               .ForMember(des => des.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
                .ForMember(des => des.ManagerId, opt => opt.MapFrom(src => src.ManagerId))
               .ForMember(des => des.RoleDepartmentLocationId, opt => opt.MapFrom(src => src.RoleDepartmentLocationId))
               .ForMember(des => des.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
              ;
            CreateMap<Employeee, EmployeeDTO>()
               .ForMember(des => des.RoleId, opt => opt.MapFrom(src => src.RoleDepartmentLocation.RoleId))
               .ForMember(des => des.RoleName, opt => opt.MapFrom(src => src.RoleDepartmentLocation.Role.RoleName))
               .ForMember(des => des.DepartmentId, opt => opt.MapFrom(src => src.RoleDepartmentLocation.DepartmentId))
               .ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => src.RoleDepartmentLocation.Department.DepartmentName))
               .ForMember(des => des.LocationId, opt => opt.MapFrom(src => src.RoleDepartmentLocation.LocationId))
               .ForMember(des => des.LocationName, opt => opt.MapFrom(src => src.RoleDepartmentLocation.Location.LocationName))
               .ForMember(des => des.ProjectName, opt => opt.MapFrom(src => src.Project.ProjectName))
               .ForMember(des => des.StatusName, opt => opt.MapFrom(src => src.Status.StatusName));
            //CreateMap<EmployeeDTO, Employeee>()
            //    .ForPath(des => des.RoleDepartmentLocation.RoleId, opt => opt.MapFrom(src => src.RoleId))
            //    .ForPath(des => des.RoleDepartmentLocation.Role.RoleName, opt => opt.MapFrom(src => src.RoleName))
            //    .ForPath(des => des.RoleDepartmentLocation.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
            //    .ForPath(des => des.RoleDepartmentLocation.Department.DepartmentName, opt => opt.MapFrom(src => src.DepartmentName))
            //    .ForPath(des => des.RoleDepartmentLocation.LocationId, opt => opt.MapFrom(src => src.LocationId))
            //    .ForPath(des => des.RoleDepartmentLocation.Location.LocationName, opt => opt.MapFrom(src => src.LocationName))
            //    .ForPath(des => des.Project.ProjectName, opt => opt.MapFrom(src => src.ProjectName))
            //    .ForPath(des => des.Status.StatusName, opt => opt.MapFrom(src => src.Status))
            //    .ReverseMap();
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
