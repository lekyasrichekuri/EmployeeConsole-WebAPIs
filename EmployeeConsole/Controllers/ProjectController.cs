using Microsoft.AspNetCore.Mvc;
using Employee.WebApi.BLL.Interfaces;
using Employee.WebApi.Models.DataTransferObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeConsole_WebAPIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public ActionResult<IEnumerable<ProjectDTO>> GetProjects()
        {
            var projects = _projectService.DisplayAll();
            if (projects.Any())
                return Ok(projects);
            else
                return NotFound("No projects found.");
        }



        // POST api/<DepartmentController>
        [HttpPost]
        public ActionResult<string> AddProject(ProjectDTO project)
        {
            if (_projectService.IsProjectNameExists(project.ProjectName))
                return Conflict($"Project '{project.ProjectName}' already exists");

            _projectService.AddProject(project);

            return Ok("Project added successfully");
        }
    }
}
