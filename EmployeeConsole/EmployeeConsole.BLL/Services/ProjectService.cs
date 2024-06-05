using Employee.WebApi.DAL.Interfaces;
using Employee.WebApi.BLL.Interfaces;
using Employee.WebApi.Models.DataTransferObjects;
using EmployeeConsole_WebAPIs.Employee.WebApi.Models.Model;
using AutoMapper;
namespace Employee.WebApi.BLL.Interfaces
{
    public class ProjectService : IProjectService
    {
        private readonly IDbService _dbService;
        private readonly IMapper _mapper;

        public ProjectService(IDbService dbService, IMapper mapper)
        {
            _dbService = dbService;
            _mapper = mapper;
        }

        public List<ProjectDTO> DisplayAll()
        {
            var projects = _dbService.DisplayAll<Project>();
            return _mapper.Map<List<ProjectDTO>>(projects);
        }

        public bool AddProject(ProjectDTO projectDTO)
        {
            var project = _mapper.Map<Project>(projectDTO);
            return _dbService.AddEntity(project);
        }

        public bool IsProjectNameExists(string project)
        {
            return _dbService.IsEntityExists<Project>(l => l.ProjectName == project, "project"); ;
        }
    }
}
