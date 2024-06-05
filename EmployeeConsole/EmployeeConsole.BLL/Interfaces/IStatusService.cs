using Employee.WebApi.Models.DataTransferObjects;

namespace Employee.WebApi.BLL.Interfaces
{
    public interface IStatusService
    {
        public List<StatusDTO> DisplayAll();
        public bool AddStatus(StatusDTO statusDTO);
        public bool IsStatusNameExists(string status);
    }
}
