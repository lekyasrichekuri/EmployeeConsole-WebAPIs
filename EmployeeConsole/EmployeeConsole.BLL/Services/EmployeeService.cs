using Employee.WebApi.DAL.Interfaces;
using Employee.WebApi.BLL.Interfaces;
using Employee.WebApi.Models.DataTransferObjects;
using EmployeeConsole_WebAPIs.Employee.WebApi.Models.Model;
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
            var employee = _mapper.Map<Employeee>(employeeDto);
            return _dbService.AddEntity(employee);
        }

        public List<EmployeeDTO> DisplayEmployees()
        {
            var employees = _dbService.DisplayAll<Employeee>();
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }

        //public bool UpdateEmployeeDetails(EmployeeDTO employeeDto)
        //{
        //    if (_dbService.IsEmployeeIdExists(employeeDto.EmployeeId))
        //    {
        //        var employee = _mapper.Map<Employeee>(employeeDto);
        //        return _dbService.UpdateEmployee(employee);
        //    }
        //    return false;
        //}

        public bool UpdateEmployeeDetails(EmployeeDTO employeeDto)
        {
            var employee = _mapper.Map<Employeee>(employeeDto);
            return _dbService.UpdateEmployee(employee);
        }

        public EmployeeDTO DisplayEmpDetails(int employeeId)
        {
            var employee = _dbService.DisplayEmployeeDetails(employeeId);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public List<EmployeeDTO> DisplayEmpDetails(string firstName, string lastName)
        {
            var employee = _dbService.DisplayEmployeeDetails(firstName,lastName);
            return _mapper.Map<List<EmployeeDTO>>(employee);
        }

        public bool DeleteEmployee(int employeeId)
        {
            return _dbService.DeleteEmployee(employeeId);
        }
    }
}
