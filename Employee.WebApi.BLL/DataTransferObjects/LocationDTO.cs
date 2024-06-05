using System.ComponentModel.DataAnnotations;

namespace EmployeeConsole.BLL.DataTransferObjects;

public partial class LocationDTO
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string LocationName { get; set; } 

}
