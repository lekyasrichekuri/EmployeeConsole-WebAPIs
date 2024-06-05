using Employee.WebApi.Models.DataTransferObjects;

namespace Employee.WebApi.BLL.Interfaces
{
    public interface IDepartmentService
    {
        public List<DepartmentDTO> DisplayAll();
        public bool AddDepartment(DepartmentDTO departmentDTO);
        public bool IsDepartmentNameExists(string department);


    }
}
