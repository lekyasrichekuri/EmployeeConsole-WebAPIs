using System.ComponentModel.DataAnnotations;

namespace Employee.WebApi.Models.DataTransferObjects;

public partial class DepartmentDTO
{

    [Required]
    [MaxLength(50)]
    public string DepartmentName { get; set; }

    [Required]
    public int IsDeleted { get; set; }
}
