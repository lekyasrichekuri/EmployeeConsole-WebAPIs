using System;
using System.Collections.Generic;

namespace EmployeeConsole_WebAPIs.EmployeeConsole.Models.Models;

public partial class Project
{
    public int Id { get; set; }

    public string ProjectName { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Employeee> Employees { get; set; } = new List<Employeee>();
}
