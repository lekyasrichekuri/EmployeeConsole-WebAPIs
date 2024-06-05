using System.ComponentModel.DataAnnotations;

namespace EmployeeConsole.BLL.DataTransferObjects;

public partial class EmployeeDTO
{
    [Required]
    public int EmployeeId { get; set; }

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

    [Required]
    public int JobTitleId { get; set; }

    [Required]
    public int DepartmentId { get; set; }

    [Required]
    public int LocationId { get; set; }

    [MaxLength(50)]
    public string? Manager { get; set; }

    [MaxLength(50)]
    public string? ProjectName { get; set; }

}
