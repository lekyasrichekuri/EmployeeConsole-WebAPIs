using AutoMapper;
using EmployeeConsole.BLL.DataTransferObjects;
using EmployeeConsole_WebAPIs.EmployeeConsole.Models.Model;

namespace EmployeeConsole.BLL.MappingProfiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<EmployeeDTO, Employee>()
                .ForMember(des => des.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(des => des.JobTitle, opt => opt.MapFrom(src => src.JobTitleId))
                .ForMember(des => des.Department, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(des => des.LocationName, opt => opt.MapFrom(src => src.LocationId))
                .ReverseMap();
        }
    }
}