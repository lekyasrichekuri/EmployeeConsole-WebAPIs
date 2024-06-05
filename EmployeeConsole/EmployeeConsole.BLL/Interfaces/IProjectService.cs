using Employee.WebApi.Models.DataTransferObjects;

namespace Employee.WebApi.BLL.Interfaces
{
    public interface IProjectService
    {
        public List<ProjectDTO> DisplayAll();
        public bool AddProject(ProjectDTO projectDTO);
        public bool IsProjectNameExists(string project);
    }
}
