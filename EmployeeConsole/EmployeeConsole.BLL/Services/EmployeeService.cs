using Employee.WebApi.DAL.Interfaces;
using Employee.WebApi.BLL.Interfaces;
using Employee.WebApi.Models.DataTransferObjects;
using EmployeeConsole_WebAPIs.Employee.WebApi.Models.Models;
using AutoMapper;

namespace Employee.WebApi.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDbService _dbService;
        private readonly IMapper _mapper;

        public EmployeeService(IDbService dbService, IMapper mapper)
        {
            _dbService = dbService;
            _mapper = mapper;
        }

        public bool AddEmployee(EmployeeDTO employeeDto)
        {
            if (!_dbService.IsEmployeeIdExists(employeeDto.EmployeeId))
            {
                var employee = _mapper.Map<Employeee>(employeeDto);
                return _dbService.AddEntity(employee);
            }
            return false;
        }

        public List<EmployeeDTO> DisplayEmployees()
        {
            var employees = _dbService.DisplayAll<Employeee>();
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }

        public bool UpdateEmployeeDetails(EmployeeDTO employeeDto)
        {
            if (_dbService.IsEmployeeIdExists(employeeDto.EmployeeId))
            {
                var employee = _mapper.Map<Employeee>(employeeDto);
                return _dbService.UpdateEmployee(employee);
            }
            return false;
        }


        public EmployeeDTO DisplayEmpDetails(string employeeId)
        {
            if (_dbService.IsEmployeeIdExists(employeeId))
            {
                var employee = _dbService.DisplayEmployeeDetails(employeeId);
                return _mapper.Map<EmployeeDTO>(employee);
            }
            return null;
        }

        public List<EmployeeDTO> DisplayEmpDetails(string firstName, string lastName)
        {
            var employee = _dbService.DisplayEmployeeDetails(firstName,lastName);
            return _mapper.Map<List<EmployeeDTO>>(employee);
        }

        public bool DeleteEmployee(string employeeId)
        {
            return _dbService.DeleteEmployee(employeeId);
        }
    }
}
