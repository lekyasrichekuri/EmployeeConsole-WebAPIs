using Employee.WebApi.Models.DataTransferObjects;

namespace Employee.WebApi.BLL.Interfaces
{
    public interface IEmployeeService
    {
        public bool AddEmployee(EmployeeDTO employeeDto);
        public List<EmployeeDTO> DisplayEmployees();
        public bool UpdateEmployeeDetails(EmployeeDTO employee);
        public EmployeeDTO DisplayEmpDetails(int employeeId);
        public List<EmployeeDTO> DisplayEmpDetails(string firstName, string lastName);
        public bool DeleteEmployee(int employeeId);
    }
}
