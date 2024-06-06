using System.ComponentModel.DataAnnotations;

namespace Employee.WebApi.Models.DataTransferObjects;

public partial class EmployeeDTO
{
    public string EmployeeId { get; set; }
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } 

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    public string? DateOfBirth { get; set; }

    [Required]
    public string Email { get; set; }

    [MaxLength(10)]
    [MinLength(10)]
    public string? PhoneNumber { get; set; }

    [Required]
    public string JoiningDate { get; set; } 

    public string ProfileImage { get; set; }

    //public int RoleId { get; set; }

    //public int DepartmentId {  get; set; }

    //public int LocationId { get; set; }

    public int RoleDepartmentLocationId { get; set; }

    public string? ManagerId { get; set; }

    public int? ProjectId { get; set; }

    public int? StatusId { get; set; }

}
