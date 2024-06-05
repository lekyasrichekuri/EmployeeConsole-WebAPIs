using Microsoft.AspNetCore.Mvc;
using Employee.WebApi.BLL.Interfaces;
using Employee.WebApi.Models.DataTransferObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeConsole_WebAPIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public ActionResult<IEnumerable<StatusDTO>> GetStatus()
        {
            var status = _statusService.DisplayAll();
            if (status.Any())
                return Ok(status);
            else
                return NotFound("No status found.");
        }



        // POST api/<DepartmentController>
        [HttpPost]
        public ActionResult<string> AddStatus(StatusDTO status)
        {
            if (_statusService.IsStatusNameExists(status.StatusName))
                return Conflict($"Status '{status.StatusName}' already exists");

            _statusService.AddStatus(status);

            return Ok("Status added successfully");
        }
    }
}
