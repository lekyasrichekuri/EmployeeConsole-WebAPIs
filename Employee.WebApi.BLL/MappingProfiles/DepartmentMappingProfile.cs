using AutoMapper;
using EmployeeConsole.BLL.DataTransferObjects;
using EmployeeConsole_WebAPIs.EmployeeConsole.Models.Model;

namespace EmployeeConsole.BLL.MappingProfiles
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<DepartmentDTO, Department>()
                .ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => src.DepartmentName));
        }
    }
}