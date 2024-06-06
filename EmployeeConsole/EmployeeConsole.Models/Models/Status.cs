using System;
using System.Collections.Generic;

namespace EmployeeConsole_WebAPIs.Employee.WebApi.Models.Models;

public partial class Status
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Employeee> Employees { get; set; } = new List<Employeee>();
}
