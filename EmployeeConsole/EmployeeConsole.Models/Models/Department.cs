using System;
using System.Collections.Generic;

namespace EmployeeConsole_WebAPIs.EmployeeConsole.Models.Models;

public partial class Department
{
    public int Id { get; set; }

    public string DepartmentName { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public virtual ICollection<RoleDepartmentLocation> RoleDepartmentLocations { get; set; } = new List<RoleDepartmentLocation>();
}
