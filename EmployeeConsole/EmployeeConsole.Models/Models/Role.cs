using System;
using System.Collections.Generic;

namespace EmployeeConsole_WebAPIs.EmployeeConsole.Models.Models;

public partial class Role
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public virtual ICollection<RoleDepartmentLocation> RoleDepartmentLocations { get; set; } = new List<RoleDepartmentLocation>();
}
