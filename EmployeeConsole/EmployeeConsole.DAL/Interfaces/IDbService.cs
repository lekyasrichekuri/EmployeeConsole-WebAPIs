using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeConsole_WebAPIs.Employee.WebApi.Models.Models;
namespace Employee.WebApi.DAL.Interfaces
{
    public interface IDbService
    {
        public bool IsEmployeeIdExists(string employeeId);
        public bool UpdateEmployee(Employeee employee);
        public Employeee DisplayEmployeeDetails(string employeeId);
        public List<Employeee> DisplayEmployeeDetails(string firstName, string lastName);
        public bool DeleteEmployee(string employeeId);
        public bool AddEntity<TEntity>(TEntity entity) where TEntity : class;
        public bool AddRoleDeptLoc(Role role);
        public bool AddRole(Role role);
        public List<TEntity> DisplayAll<TEntity>() where TEntity : class;
        public bool IsEntityExists<TEntity>(Func<TEntity, bool> predicate, string entityName) where TEntity : class;
    }
}
