using Employee.WebApi.DAL.Interfaces;
using Employee.WebApi.BLL.Interfaces;
using Employee.WebApi.Models.DataTransferObjects;
using EmployeeConsole_WebAPIs.Employee.WebApi.Models.Models;
using AutoMapper;

namespace Employee.WebApi.BLL.Services
{
    public class LocationService : ILocationService
    {
        private readonly IDbService _dbService;
        private readonly IMapper _mapper;

        public LocationService(IDbService dbService,IMapper mapper)
        {
            _dbService = dbService;
            _mapper = mapper;
        }

        public List<LocationDTO> DisplayAll()
        {
            var locations = _dbService.DisplayAll<Location>();
            return _mapper.Map<List<LocationDTO>>(locations);
        }

        public bool AddLocation(LocationDTO locationDTO)
        {
            var location = _mapper.Map<Location>(locationDTO);
            return _dbService.AddEntity(location);
        }

        public bool IsLocationNameExists(string location)
        {
            return _dbService.IsEntityExists<Location>(l => l.LocationName == location, "location"); ;
        }
    }
}
