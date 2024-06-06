using System;
using System.Collections.Generic;

namespace EmployeeConsole_WebAPIs.Employee.WebApi.Models.Models;

public partial class Employeee
{
    public string EmployeeId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? DateOfBirth { get; set; }

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string JoiningDate { get; set; } = null!;

    public string? ProfileImage { get; set; }

    public int RoleDepartmentLocationId { get; set; }

    public string? ManagerId { get; set; }

    public int? ProjectId { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<Employeee> InverseManager { get; set; } = new List<Employeee>();

    public virtual Employeee? Manager { get; set; }

    public virtual Project? Project { get; set; }

    public virtual RoleDepartmentLocation RoleDepartmentLocation { get; set; } = null!;

    public virtual Status? Status { get; set; }
}
