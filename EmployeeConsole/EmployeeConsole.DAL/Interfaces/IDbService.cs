using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeConsole_WebAPIs.EmployeeConsole.Models.Models;
namespace Employee.WebApi.DAL.Interfaces
{
    public interface IDbService
    {
        public bool IsEmployeeIdExists(string employeeId);
        public bool UpdateEmployee(Employeee employee);
        public Employeee DisplayEmployeeDetails(string employeeId);
        public List<Employeee> DisplayEmployeeDetails(string firstName, string lastName);
        public List<Employeee> DisplayEmpDetailsOnFirstLetter(string letter);
        public bool DeleteEmployee(string employeeId);
        public bool AddEmployee(Employeee employee);
        public bool AddEntity<TEntity>(TEntity entity) where TEntity : class;
        public bool AddRoleDeptLoc(Role role);
        public bool AddRole(Role role);
        public List<Employeee> DisplayEmployees();
        public List<Role> DisplayRoles();
        public List<Department> DisplayDepartments();
        public List<Location> DisplayLocations();
        public List<Project> DisplayProjects();
        public List<Status> DisplayStatus();
        public bool IsEntityExists<TEntity>(Func<TEntity, bool> predicate, string entityName) where TEntity : class;
    }
}
