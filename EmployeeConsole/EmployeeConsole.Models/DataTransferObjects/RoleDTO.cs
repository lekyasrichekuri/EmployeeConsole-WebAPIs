using System.ComponentModel.DataAnnotations;

namespace Employee.WebApi.Models.DataTransferObjects;

public partial class RoleDTO
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string RoleName { get; set; }

    [Required]
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; }

    [Required]
    public int LocationId { get; set; }

    public string LocationName { get; set; }

    public string RoleDescription { get; set; }

    [Required]
    public bool IsDeleted { get; set; }
}
