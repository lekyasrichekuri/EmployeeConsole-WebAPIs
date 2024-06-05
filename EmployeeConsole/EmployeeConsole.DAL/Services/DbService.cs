using Employee.WebApi.DAL.Interfaces;
using EmployeeConsole_WebAPIs.Employee.WebApi.Models.Model;
namespace Employee.WebApi.DAL.Services
{
    public class DbService : IDbService
    {
        private readonly LekyaDbContext _context;
        public DbService(LekyaDbContext context)
        {
            _context = context;
        }

        //public bool IsEmployeeIdExists(int employeeId)
        //{
        //    if (_context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId) != null)
        //        return true;
        //    return false;
        //}

        public bool UpdateEmployee(Employeee employee)
        {
            try
            {
                var employeeToUpdate = _context.Employees.Find(employee.EmployeeId);

                if (employeeToUpdate != null)
                {
                    employeeToUpdate.FirstName = employee.FirstName;
                    employeeToUpdate.LastName = employee.LastName;
                    employeeToUpdate.Email = employee.Email;
                    employeeToUpdate.PhoneNumber = employee.PhoneNumber;
                    employeeToUpdate.Manager = employee.Manager;
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while updating an employee: {e.Message}");
                return false;
            }
        }

        public Employeee DisplayEmployeeDetails(int employeeId)
        {
            try
            {
                var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
                if (employee != null)
                {
                    return employee;
                }
                else
                {
                    Console.WriteLine("Employee doesn't exist");
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while displaying employee details: {e.Message}");
                return null;
            }
        }

        public List<Employeee> DisplayEmployeeDetails(string firstName, string lastName)
        {
            try
            {
                var employees = _context.Employees
                .Where(e =>
                     e.FirstName.ToUpper().Contains(firstName.ToUpper()) ||
                     e.LastName.ToUpper().Contains(lastName.ToUpper()))
                .ToList();
                List<Employeee> employ=new List<Employeee>();
                foreach(var employee in employees)
                {
                    var emp = new Employeee
                    {
                        EmployeeId=employee.EmployeeId,
                        Email=employee.Email,
                        Manager=employee.Manager,
                    };
                    employ.Add(emp);
                }
                return employ;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while displaying employee details: {e.Message}");
                return null;
            }
        }


        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                var employeeToDelete = _context.Employees.Find(employeeId);
                if (employeeToDelete != null)
                {
                    _context.Employees.Remove(employeeToDelete);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("Employee doesn't exist");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while deleting an employee: {e.Message}");
                return false;
            }
        }

        public List<TEntity> DisplayAll<TEntity>() where TEntity : class
        {
            var entities = new List<TEntity>();
            try
            {
                entities = _context.Set<TEntity>().ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while displaying {typeof(TEntity).Name}s: {e.Message}");
            }
            return entities;
        }

        public bool AddEntity<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while adding the entity: {e.Message}");
                return false;
            }
        }

        public bool AddRole(Role role)
        {
            try
            {
                Role r = new Role();
                r.RoleName=role.RoleName;
                _context.Roles.Add(role);
                RoleDepartmentLocation roleDepartmentLocation = new RoleDepartmentLocation();
                roleDepartmentLocation.RoleId = role.Id;
                roleDepartmentLocation.DepartmentId = role.DepartmentId;
                roleDepartmentLocation.RoleDescription = role.RoleDescription;
                roleDepartmentLocation.LocationId = role.LocationId;
                _context.RoleDepartmentLocations.Add(roleDepartmentLocation);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while adding the Role: {e.Message}");
                return false;
            }
        }

        public bool IsEntityExists<TEntity>(Func<TEntity, bool> predicate, string entityName) where TEntity : class
        {
            try
            {
                if (_context.Set<TEntity>().FirstOrDefault(predicate) == null)
                    return false;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while checking if the {entityName} exists: {e.Message}");
                return false;
            }
        }
    }
}
