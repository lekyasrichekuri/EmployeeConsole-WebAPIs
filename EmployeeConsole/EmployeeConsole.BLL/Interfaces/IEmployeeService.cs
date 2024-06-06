using Employee.WebApi.Models.DataTransferObjects;

namespace Employee.WebApi.BLL.Interfaces
{
    public interface IEmployeeService
    {
        public bool AddEmployee(EmployeeDTO employeeDto);
        public List<EmployeeDTO> DisplayEmployees();
        public bool UpdateEmployeeDetails(EmployeeDTO employee);
        public EmployeeDTO DisplayEmpDetails(string employeeId);
        public List<EmployeeDTO> DisplayEmpDetails(string firstName, string lastName);
        public bool DeleteEmployee(string employeeId);
    }
}
