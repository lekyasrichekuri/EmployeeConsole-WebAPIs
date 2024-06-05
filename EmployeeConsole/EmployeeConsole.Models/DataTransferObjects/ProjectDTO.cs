using System.ComponentModel.DataAnnotations;

namespace Employee.WebApi.Models.DataTransferObjects;

public partial class ProjectDTO
{

    [Required]
    [MaxLength(50)]
    public string ProjectName { get; set; }

    [Required]
    public int IsDeleted { get; set; }
}
