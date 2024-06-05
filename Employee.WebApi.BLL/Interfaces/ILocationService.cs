using EmployeeConsole.BLL.DataTransferObjects;

namespace EmployeeConsole.BLL.Interfaces
{
    public interface ILocationService
    {
        public bool AddLocation(LocationDTO LocationName);
    }
}
