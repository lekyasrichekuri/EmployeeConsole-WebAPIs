using Microsoft.AspNetCore.Mvc;
using Employee.WebApi.BLL.Interfaces;
using Employee.WebApi.Models.DataTransferObjects;

namespace Employee.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // POST api/Role
        [HttpPost]
        public ActionResult<string> AddRole(RoleDTO role)
        {
            if (role == null)
                return BadRequest("Role object is null");

            if (role.RoleName==null)
                return BadRequest("Role Name cannot be empty");

            if (_roleService.IsRoleNameExists(role.RoleName))
                return Conflict($"Role '{role.RoleName}' already exists");

            bool a = _roleService.AddRole(role);

            return Ok("Role added successfully");
        }

        // GET: api/Role
        [HttpGet]
        public ActionResult<IEnumerable<RoleDTO>> GetRoles()
        {
            var roles = _roleService.DisplayAll();
            if (roles.Any())
                return Ok(roles);
            else
                return NotFound("No roles found.");
        }
    }
}