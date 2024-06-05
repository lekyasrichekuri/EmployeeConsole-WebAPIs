using AutoMapper;
using EmployeeConsole.BLL.Interfaces;
using EmployeeConsole.DAL.Interfaces;
using EmployeeConsole_WebAPIs.EmployeeConsole.Models.Model;
using EmployeeConsole.BLL.DataTransferObjects;
using System;

namespace EmployeeConsole.BLL.Services
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

        public void AddEmployee(EmployeeDTO employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            if (_dbService.AddEmployee(employee))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Employee added Successfully");
                Console.ResetColor();
            }
        }

        public Dictionary<int, EmployeeDTO> DisplayEmployees()
        {
            var employees = _dbService.DisplayEmployees();
            return _mapper.Map<Dictionary<int, EmployeeDTO>>(employees);
        }

        public bool UpdateEmployeeDetails(EmployeeDTO employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            return _dbService.UpdateEmployee(employee);
        }

        public EmployeeDTO DisplayEmpDetails(int employeeId)
        {
            var employee = _dbService.DisplayEmployeeDetails(employeeId);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public bool DeleteEmployee(int employeeId)
        {
            return _dbService.DeleteEmployee(employeeId);
        }
    }
}
