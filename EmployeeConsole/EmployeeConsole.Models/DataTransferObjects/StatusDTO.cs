using System.ComponentModel.DataAnnotations;

namespace Employee.WebApi.Models.DataTransferObjects;

public partial class StatusDTO
{

    [Required]
    [MaxLength(50)]
    public string StatusName { get; set; }

}
