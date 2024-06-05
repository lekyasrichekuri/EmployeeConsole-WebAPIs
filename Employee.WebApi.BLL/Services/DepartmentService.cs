using EmployeeConsole.DAL.Interfaces;
using EmployeeConsole.BLL.Interfaces;
using EmployeeConsole.BLL.DataTransferObjects;
using EmployeeConsole_WebAPIs.EmployeeConsole.Models.Model;
using AutoMapper;

namespace EmployeeConsole.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDbService _dbService;
        private readonly IMapper _mapper;
        public DepartmentService(IDbService dbService,IMapper mapper)
        {
            _dbService = dbService;
            _mapper = mapper;
        }

        public bool AddDepartment(DepartmentDTO departmentName)
        {
            var department = _mapper.Map<Department>(departmentName);
            if (_dbService.AddDepartmentOrLocation<Department>(department, "Department", "DepartmentName"))
                return true;
            return false;
        }
    }
}
