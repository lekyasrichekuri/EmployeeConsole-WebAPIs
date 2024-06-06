using Employee.WebApi.DAL.Interfaces;
using Employee.WebApi.BLL.Interfaces;
using Employee.WebApi.Models.DataTransferObjects;
using EmployeeConsole_WebAPIs.Employee.WebApi.Models.Models;
using AutoMapper;

namespace Employee.WebApi.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDbService _dbService;
        private readonly IMapper _mapper;
        public DepartmentService(IDbService dbService, IMapper mapper)
        {
            _dbService = dbService;
            _mapper = mapper;
        }

        public List<DepartmentDTO> DisplayAll()
        {
            var departments = _dbService.DisplayAll<Department>();
            return _mapper.Map<List<DepartmentDTO>>(departments);
        }

        public bool AddDepartment(DepartmentDTO departmentDTO)
        {
            var department = _mapper.Map<Department>(departmentDTO);
            return _dbService.AddEntity(department);
        }

        public bool IsDepartmentNameExists(string department)
        {
            return _dbService.IsEntityExists<Department>(l => l.DepartmentName == department, "department");
        }
    }
}
