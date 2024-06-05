using EmployeeConsole.BLL.DataTransferObjects;

namespace EmployeeConsole.BLL.Interfaces
{
    public interface IEmployeeService
    {
        public void AddEmployee(EmployeeDTO employeeDto);
        public Dictionary<int, EmployeeDTO> DisplayEmployees();
        public bool UpdateEmployeeDetails(EmployeeDTO employee);
        public EmployeeDTO DisplayEmpDetails(int employeeId);
        public bool DeleteEmployee(int employeeId);
    }
}
