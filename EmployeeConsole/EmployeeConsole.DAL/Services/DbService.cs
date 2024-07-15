using Employee.WebApi.DAL.Interfaces;
using EmployeeConsole_WebAPIs.EmployeeConsole.Models.Models;
using Microsoft.EntityFrameworkCore;
namespace Employee.WebApi.DAL.Services
{
    public class DbService : IDbService
    {
        private readonly LekyaDbContext _context;
        public DbService(LekyaDbContext context)
        {
            _context = context;
        }

        public bool IsEmployeeIdExists(string employeeId)
        {
            if (_context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId) != null)
                return true;
            return false;
        }

        public bool UpdateEmployee(Employeee employee)
        {
            try
            {
                var employeeToUpdate = _context.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);

                if (employeeToUpdate != null)
                {
                    employeeToUpdate.EmployeeId = employee.EmployeeId;
                    employeeToUpdate.FirstName = employee.FirstName;
                    employeeToUpdate.LastName = employee.LastName;
                    employeeToUpdate.Email = employee.Email;
                    employeeToUpdate.PhoneNumber= employee.PhoneNumber;
                    employeeToUpdate.DateOfBirth = employee.DateOfBirth;
                    employeeToUpdate.RoleDepartmentLocationId = employee.RoleDepartmentLocationId;
                    employeeToUpdate.JoiningDate= employee.JoiningDate;
                    employeeToUpdate.ProfileImage= employee.ProfileImage;
                    employeeToUpdate.ManagerId= employee.ManagerId;
                    employeeToUpdate.ProjectId= employee.ProjectId;
                    employeeToUpdate.StatusId= employee.StatusId;
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

        public Employeee DisplayEmployeeDetails(string employeeId)
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
                .Include(e => e.RoleDepartmentLocation)
                    .ThenInclude(rdl => rdl.Role)
                .Include(e => e.RoleDepartmentLocation)
                    .ThenInclude(rdl => rdl.Department)
                .Include(e => e.RoleDepartmentLocation)
                    .ThenInclude(rdl => rdl.Location)
                .Include(e => e.Project)
                .Include(e => e.Status)
                .ToList();
                return employees;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while displaying employee details: {e.Message}");
                return null;
            }
        }


        public List<Employeee> DisplayEmpDetailsOnFirstLetter(string letter)
        {
            try
            {
                var employees = _context.Employees
                    .Where(e => e.FirstName.ToUpper().StartsWith(letter))
                    .Include(e => e.RoleDepartmentLocation)
                        .ThenInclude(rdl => rdl.Role)
                    .Include(e => e.RoleDepartmentLocation)
                        .ThenInclude(rdl => rdl.Department)
                    .Include(e => e.RoleDepartmentLocation)
                        .ThenInclude(rdl => rdl.Location)
                    .Include(e => e.Project)
                    .Include(e => e.Status)
                    .ToList();
                return employees;
            }
            catch(Exception e)
            {
                Console.WriteLine($"An error has occurred while displaying employee details: {e.Message}");
                return null;
            }
        }


        public bool DeleteEmployee(string employeeId)
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

        public List<Employeee> DisplayEmployees()
        {
            try
            {
                return _context.Employees
                               .Include(e => e.RoleDepartmentLocation)
                                   .ThenInclude(rdl => rdl.Role)
                               .Include(e => e.RoleDepartmentLocation)
                                   .ThenInclude(rdl => rdl.Department)
                               .Include(e => e.RoleDepartmentLocation)
                                   .ThenInclude(rdl => rdl.Location)
                               .Include(e => e.Project)
                               .Include(e => e.Status)
                               .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while displaying employees: {e.Message}");
                return null;
            }
        }

        public List<Role> DisplayRoles()
        {
            try
            {
                return _context.Roles
                    .ToList();
            }
            catch(Exception e)
            {
                Console.WriteLine($"An error occurred while displaying roles:{e.Message}");
                return null;
            }
        }

        public List<Department> DisplayDepartments()
        {
            try
            {
                return _context.Departments
                    .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while displaying departments:{e.Message}");
                return null;
            }
        }
        public List<Location> DisplayLocations()
        {
            try
            {
                return _context.Locations
                    .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while displaying locations:{e.Message}");
                return null;
            }
        }

        public List<Project> DisplayProjects()
        {
            try
            {
                return _context.Projects
                    .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while displaying projects:{e.Message}");
                return null;
            }
        }
        public List<Status> DisplayStatus()
        {
            try
            {
                return _context.Statuses
                    .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while displaying status:{e.Message}");
                return null;
            }
        }



        /*        public List<TEntity> DisplayAll<TEntity>() where TEntity : class
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
                }*/

        public bool AddEmployee(Employeee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while adding the employee: {e.Message}");
                return false;
            }
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

        public bool AddRoleDeptLoc(Role role)
        {
            try
            {
                var existingRole = _context.Roles.FirstOrDefault(r => r.RoleName == role.RoleName);
                if (existingRole == null)
                {
                    _context.Roles.Add(role);
                    _context.SaveChanges(); 
                }
                else
                {
                    role.Id = existingRole.Id;
                }
                foreach (var roleDepartmentLocation in role.RoleDepartmentLocations)
                {
                    var existingRDL = _context.RoleDepartmentLocations
                                            .FirstOrDefault(rdl => rdl.RoleId == role.Id &&
                                                                     rdl.DepartmentId == roleDepartmentLocation.DepartmentId &&
                                                                     rdl.LocationId == roleDepartmentLocation.LocationId);

                    if (existingRDL == null)
                    {
                        roleDepartmentLocation.RoleId = role.Id;
                        _context.RoleDepartmentLocations.Add(roleDepartmentLocation);
                    }
                }

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Inner exception: {ex.InnerException?.Message}");
                return false;
            }
        }




        public bool AddRole(Role role)
        {
            try
            {
                if (!role.RoleDepartmentLocations.Any())
                {
                    Console.WriteLine("RoleDepartmentLocations collection is empty.");
                    return false;
                }

                var firstRoleDepartmentLocation = role.RoleDepartmentLocations.First();

                var departmentExists = _context.Departments.Any(d => d.Id == firstRoleDepartmentLocation.DepartmentId);
                var locationExists = _context.Locations.Any(l => l.Id == firstRoleDepartmentLocation.LocationId);

                if (!departmentExists || !locationExists)
                {
                    Console.WriteLine("Department or Location does not exist.");
                    return false;
                }

                var roleName = _context.Employees.Find(role.RoleName);
                if(roleName==null)
                {
                    _context.Roles.Add(role);
                    _context.SaveChanges();
                }

                foreach (var roleDepartmentLocation in role.RoleDepartmentLocations)
                {
                    roleDepartmentLocation.RoleId = role.Id;
                    _context.RoleDepartmentLocations.Add(roleDepartmentLocation);
                }
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AutoMapper error: {ex.Message}");
                Console.WriteLine($"Inner exception: {ex.InnerException?.Message}");
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
