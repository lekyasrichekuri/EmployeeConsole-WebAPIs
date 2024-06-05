using AutoMapper;
using EmployeeConsole.DAL.Interfaces;
using EmployeeConsole.BLL.Interfaces;
using EmployeeConsole.BLL.DataTransferObjects;
using EmployeeConsole_WebAPIs.EmployeeConsole.Models.Model;

namespace EmployeeConsole.BLL.Services
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
            var roles = _dbService.DisplayRoles();
            return _mapper.Map<List<RoleDTO>>(roles);
        }

        public bool AddRole(RoleDTO roleDTO)
        {
            var role = _mapper.Map<Role>(roleDTO);
            return _dbService.AddRole(role);
        }

        public bool IsRoleNameExists(string role)
        {
            return _dbService.IsRoleExists(role);
        }
    }
}

