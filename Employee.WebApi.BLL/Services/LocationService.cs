using EmployeeConsole.DAL.Interfaces;
using EmployeeConsole.BLL.Interfaces;
using EmployeeConsole.BLL.DataTransferObjects;
using EmployeeConsole_WebAPIs.EmployeeConsole.Models.Model;
using AutoMapper;


namespace EmployeeConsole.BLL.Services
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

        public bool AddLocation(LocationDTO locationName)
        {
            var location = _mapper.Map<Location>(locationName);
            if (_dbService.AddDepartmentOrLocation<Location>(location, "Locations", "LocationName"))
                return true;
            return false;
        }
    }
}
