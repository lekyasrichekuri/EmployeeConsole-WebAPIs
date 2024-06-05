using System.ComponentModel.DataAnnotations;

namespace Employee.WebApi.Models.DataTransferObjects;

public partial class EmployeeDTO
{

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

    public string JobTitle { get; set; }
    public string Department {  get; set; }
    public string Location { get; set; }
    [Required]
   // public int RoleDepartmentLocationId { get; set; }

    public int? ManagerId { get; set; }

    public int? ProjectId { get; set; }

    public int? StatusId { get; set; }

}
