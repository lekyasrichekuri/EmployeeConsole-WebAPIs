using Employee.WebApi.DAL.Interfaces;
using Employee.WebApi.BLL.Interfaces;
using Employee.WebApi.Models.DataTransferObjects;
using EmployeeConsole_WebAPIs.Employee.WebApi.Models.Models;
using AutoMapper;
namespace Employee.WebApi.BLL.Interfaces
{
    public class StatusService : IStatusService
    {
        private readonly IDbService _dbService;
        private readonly IMapper _mapper;

        public StatusService(IDbService dbService, IMapper mapper)
        {
            _dbService = dbService;
            _mapper = mapper;
        }

        public List<StatusDTO> DisplayAll()
        {
            var status = _dbService.DisplayAll<Status>();
            return _mapper.Map<List<StatusDTO>>(status);
        }

        public bool AddStatus(StatusDTO statusDTO)
        {
            var status = _mapper.Map<Status>(statusDTO);
            return _dbService.AddEntity(status);
        }

        public bool IsStatusNameExists(string status)
        {
            return _dbService.IsEntityExists<Status>(l => l.StatusName == status, "status"); ;
        }
    }
}
