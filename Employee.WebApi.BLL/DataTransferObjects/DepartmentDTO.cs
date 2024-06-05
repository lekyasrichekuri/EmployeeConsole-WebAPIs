using System.ComponentModel.DataAnnotations;

namespace EmployeeConsole.BLL.DataTransferObjects;

public partial class DepartmentDTO
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string DepartmentName { get; set; }
}
