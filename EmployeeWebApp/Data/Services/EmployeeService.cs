using EmployeeWebApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApp.Data.Services
{
    public class EmployeeService
    {
        readonly EmployeesDbContext _dbContext = new();

        public EmployeeService(EmployeesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// To Get all Employees
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployees()
        {
            try
            {
                return _dbContext.Employees.ToList();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// To Add new Employee record
        /// </summary>
        /// <param name="Employee"></param>
        public void AddEmployee(Employee Employee)
        {
            try
            {
                _dbContext.Employees.Add(Employee);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// To Update the records of a particluar Employee
        /// </summary>
        /// <param name="Employee"></param>
        public void UpdateEmployeeDetails(Employee Employee)
        {
            try
            {
                _dbContext.Entry(Employee).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get the details of a particular Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetEmployeeData(int id)
        {
            try
            {
                Employee? Employee = _dbContext.Employees.Find(id);
                if (Employee != null)
                {
                    return Employee;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// To Delete the record of a particular Employee
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEmployee(int id)
        {
            try
            {
                Employee? Employee = _dbContext.Employees.Find(id);
                if (Employee != null)
                {
                    _dbContext.Employees.Remove(Employee);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
