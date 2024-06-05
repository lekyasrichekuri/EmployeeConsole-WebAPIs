using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeConsole_WebAPIs.Employee.WebApi.Models.Model;
namespace Employee.WebApi.DAL.Interfaces
{
    public interface IDbService
    {
      //  public bool IsEmployeeIdExists(int employeeId);
        public bool UpdateEmployee(Employeee employee);
        public Employeee DisplayEmployeeDetails(int employeeId);
        public List<Employeee> DisplayEmployeeDetails(string firstName, string lastName);
        public bool DeleteEmployee(int employeeId);
        public bool AddEntity<TEntity>(TEntity entity) where TEntity : class;
        public bool AddRole(Role role);
        public List<TEntity> DisplayAll<TEntity>() where TEntity : class;
        public bool IsEntityExists<TEntity>(Func<TEntity, bool> predicate, string entityName) where TEntity : class;
    }
}
