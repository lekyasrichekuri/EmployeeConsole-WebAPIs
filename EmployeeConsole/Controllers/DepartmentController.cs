using Microsoft.AspNetCore.Mvc;
using Employee.WebApi.BLL.Interfaces;
using Employee.WebApi.Models.DataTransferObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeConsole_WebAPIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public ActionResult<IEnumerable<DepartmentDTO>> GetDepartments()
        {
            var departments = _departmentService.DisplayAll();
            if (departments.Any())
                return Ok(departments);
            else
                return NotFound("No departments found.");
        }

        

        // POST api/<DepartmentController>
        [HttpPost]
        public ActionResult<string> AddDepartment(DepartmentDTO department)
        {
            if (department == null)
                return BadRequest("Department object is null");

            if (department.DepartmentName == null)
                return BadRequest("Department Name cannot be empty");

            if (_departmentService.IsDepartmentNameExists(department.DepartmentName))
                return Conflict($"Department '{department.DepartmentName}' already exists");

            _departmentService.AddDepartment(department);

            return Ok("Department added successfully");
        }
    }
}
