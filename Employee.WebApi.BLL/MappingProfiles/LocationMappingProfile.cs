using AutoMapper;
using EmployeeConsole.BLL.DataTransferObjects;
using EmployeeConsole_WebAPIs.EmployeeConsole.Models.Model;

namespace EmployeeConsole.BLL.MappingProfiles
{
    public class LocationMappingProfile : Profile
    {
        public LocationMappingProfile()
        {
            CreateMap<LocationDTO, Location>()
                .ForMember(des => des.LocationName, opt => opt.MapFrom(src => src.LocationName));
        }
    }
}
