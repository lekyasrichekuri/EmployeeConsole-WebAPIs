using EmployeeConsole.BLL.DataTransferObjects;

namespace EmployeeConsole.BLL.Interfaces
{
    public interface IDepartmentService
    {
        public bool AddDepartment(DepartmentDTO Department);
    }
}
