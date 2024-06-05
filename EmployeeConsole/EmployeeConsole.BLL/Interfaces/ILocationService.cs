using Employee.WebApi.Models.DataTransferObjects;

namespace Employee.WebApi.BLL.Interfaces
{
    public interface ILocationService
    {
        public List<LocationDTO> DisplayAll();
        public bool AddLocation(LocationDTO locationDTO);
        public bool IsLocationNameExists(string location);

    }
}
