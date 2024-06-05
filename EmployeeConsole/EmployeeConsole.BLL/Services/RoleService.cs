using Employee.WebApi.DAL.Interfaces;
using Employee.WebApi.BLL.Interfaces;
using Employee.WebApi.Models.DataTransferObjects;
using EmployeeConsole_WebAPIs.Employee.WebApi.Models.Model;
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
            var roles = _dbService.DisplayAll<Role>();
            return _mapper.Map<List<RoleDTO>>(roles);
        }

        public bool AddRole(RoleDTO roleDTO)
        {
            var role = _mapper.Map<Role>(roleDTO);
            return _dbService.AddRole(role);
        }


        public bool IsRoleNameExists(string role)
        {
            return _dbService.IsEntityExists<Role>(r => r.RoleName == role, "role");
        }
    }
}

