using Microsoft.AspNetCore.Mvc;
using Employee.WebApi.BLL.Interfaces;
using Employee.WebApi.Models.DataTransferObjects;

namespace Employee.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            var employees = _employeeService.DisplayEmployees();
            if (employees.Any())
                return Ok(employees);
            else
                return NotFound("No employees found.");
        }

        // GET api/Employee/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeDTO> GetEmployeeById(int id)
        {
            var employee = _employeeService.DisplayEmpDetails(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        //GET api/Employee/name
        [HttpGet("{name}")]
        public ActionResult<EmployeeDTO> GetEmployeeByName(string name)
        {
            var names = name.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (names.Length == 1)
            {
                var firstName = names[0];
                var lastName = names[0];
                var employee = _employeeService.DisplayEmpDetails(firstName, lastName);
                if (employee != null)
                    return Ok(employee);
            }
            else if (names.Length == 2)
            { 
                var firstName = names[0];
                var lastName = names[1];
                var employee = _employeeService.DisplayEmpDetails(firstName, lastName);
                if (employee != null)
                    return Ok(employee);
            }
            return NotFound("Employee not found");
        }

        // POST api/Employee
        [HttpPost]
        public ActionResult<string> AddEmployee(EmployeeDTO employee)
        {
            _employeeService.AddEmployee(employee);
            return Ok("Employee added successfully");
        }

        // PUT api/Employee/5
        [HttpPut("{id}")]
        public ActionResult<string> UpdateEmployee(string id, EmployeeDTO employee)
        {
            var success = _employeeService.UpdateEmployeeDetails(employee);
            if (success)
                return Ok($"Employee with ID {id} updated successfully");
            else
                return NotFound($"Employee with ID {id} not found");
        }

        // DELETE api/Employee/5
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteEmployee(int id)
        {
            var success = _employeeService.DeleteEmployee(id);
            if (success)
                return Ok($"Employee with ID {id} deleted successfully");
            else
                return NotFound($"Employee with ID {id} not found");
        }
    }
}
