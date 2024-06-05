using Microsoft.AspNetCore.Mvc;
using Employee.WebApi.BLL.Interfaces;
using Employee.WebApi.Models.DataTransferObjects;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeConsole_WebAPIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public ActionResult<IEnumerable<LocationDTO>> GetLocations()
        {
            var locations = _locationService.DisplayAll();
            if (locations.Any())
                return Ok(locations);
            else
                return NotFound("No locations found.");
        }



        // POST api/<DepartmentController>
        [HttpPost]
        public ActionResult<string> AddLocation(LocationDTO location)
        {
            if (location == null)
                return BadRequest("Location object is null");

            if (location.LocationName == null)
                return BadRequest("Loctaion Name cannot be empty");

            if (_locationService.IsLocationNameExists(location.LocationName))
                return Conflict($"Location '{location.LocationName}' already exists");

            _locationService.AddLocation(location);

            return Ok("Location added successfully");
        }
    }
}
