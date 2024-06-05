using EmployeeConsole.BLL.DataTransferObjects;

namespace EmployeeConsole.BLL.Interfaces
{
    public interface IRoleService
    {
        public bool IsRoleNameExists(string roleName);
        public bool AddRole(RoleDTO roleDTO);
        public List<RoleDTO> DisplayAll();
    }
}
