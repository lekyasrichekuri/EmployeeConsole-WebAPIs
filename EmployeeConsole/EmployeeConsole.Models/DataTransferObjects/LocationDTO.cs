using System.ComponentModel.DataAnnotations;

namespace Employee.WebApi.Models.DataTransferObjects;

public partial class LocationDTO
{

    [Required]
    [MaxLength(50)]
    public string LocationName { get; set; }

    [Required]
    public int IsDeleted { get; set; }
}
