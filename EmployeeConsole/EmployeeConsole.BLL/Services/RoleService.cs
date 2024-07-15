using Employee.WebApi.DAL.Interfaces;
using Employee.WebApi.BLL.Interfaces;
using Employee.WebApi.Models.DataTransferObjects;
using EmployeeConsole_WebAPIs.EmployeeConsole.Models.Models;
using AutoMapper;

namespace Employee.WebApi.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IDbService _dbService;
        private readonly IMapper _mapper;

        public RoleService(IDbService dbService, IMapper mapper)
        {
            _dbService = dbService;
            _mapper = mapper;
        }

        public List<RoleDTO> DisplayAll()
        {
            List<Role> roles = null;
            try
            {
                roles = _dbService.DisplayRoles();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while retrieving roles: {e.Message}");
                return new List<RoleDTO>(); 
            }

            try
            {
                return _mapper.Map<List<RoleDTO>>(roles);
            }
            catch (AutoMapperMappingException ex)
            {
                Console.WriteLine($"AutoMapper error: {ex.Message}");
                Console.WriteLine($"Inner exception: {ex.InnerException?.Message}");
                return new List<RoleDTO>();
            }
        }


        public bool AddRole(RoleDTO roleDTO)
        {
            var role = _mapper.Map<Role>(roleDTO);
            return _dbService.AddRole(role);
        }

        public bool AddRoleDeptLoc(RoleDTO roleDTO)
        {
            var role= _mapper.Map<Role>(roleDTO);
            return _dbService.AddRoleDeptLoc(role);
        }

        public bool IsRoleNameExists(string role)
        {
            return _dbService.IsEntityExists<Role>(r => r.RoleName == role, "role");
        }
    }
}

