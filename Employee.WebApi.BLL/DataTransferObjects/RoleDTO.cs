using System.ComponentModel.DataAnnotations;

namespace Employee.WebApi.BLL.DataTransferObjects;

public partial class RoleDTO
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string RoleName { get; set; }

    [Required]
    public int DepartmentId { get; set; }

    [MaxLength(50)]
    public string? Description { get; set; }

    [Required]
    public int LocationId { get; set; }
}
