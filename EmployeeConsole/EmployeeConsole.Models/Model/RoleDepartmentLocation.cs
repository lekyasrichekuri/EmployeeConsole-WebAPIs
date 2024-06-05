using System;
using System.Collections.Generic;

namespace EmployeeConsole_WebAPIs.Employee.WebApi.Models.Model;

public partial class RoleDepartmentLocation
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public int DepartmentId { get; set; }

    public string RoleDescription { get; set; } = null!;

    public int LocationId { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Employeee> Employees { get; set; } = new List<Employeee>();

    public virtual Location Location { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
