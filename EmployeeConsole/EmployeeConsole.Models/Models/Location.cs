using System;
using System.Collections.Generic;

namespace EmployeeConsole_WebAPIs.Employee.WebApi.Models.Models;

public partial class Location
{
    public int Id { get; set; }

    public string LocationName { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public virtual ICollection<RoleDepartmentLocation> RoleDepartmentLocations { get; set; } = new List<RoleDepartmentLocation>();
}
