using Employee.WebApi.Models.DataTransferObjects;

namespace Employee.WebApi.BLL.Interfaces
{
    public interface IRoleService
    {
        public bool IsRoleNameExists(string roleName);
        public bool AddRole(RoleDTO roleDTO);
        public List<RoleDTO> DisplayAll();
        public bool AddRoleDeptLoc(RoleDTO roleDTO);
    }
}
