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

                var _data = (from emp in _dbContext.Employees
                             join pic in this._dbContext.EmployeeProfilePics on emp.Id equals pic.EmployeeId into p
                             from pic in p.DefaultIfEmpty()
                             select new Employee
                             {
                                 Id = emp.Id,
                                 Code = emp.Code,
                                 FullName = emp.FullName,
                                 Dob = emp.Dob,
                                 Address = emp.Address,
                                 City = emp.City,
                                 PostalCode = emp.PostalCode,
                                 State = emp.State,
                                 Country = emp.Country,
                                 EmailAddress = emp.EmailAddress,
                                 PhoneNo = emp.PhoneNo,
                                 StartingDate = emp.StartingDate,
                                 ImageType = pic.ImageType,
                                 Thumbnail = pic.Thumbnail,
                                 EmployeeProfilePicId = pic.Id
                             }).ToList();
                return _data;
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
        public void AddEmployee(Employee employee)
        {
            try
            {
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();

                if (!string.IsNullOrEmpty(employee.Thumbnail) && employee.Id > 0)
                {
                    EmployeeProfilePic employeeProfilePic = new EmployeeProfilePic();
                    employeeProfilePic.Id = employee.EmployeeProfilePicId > 0 ? (int)employee.EmployeeProfilePicId : 0;
                    employeeProfilePic.ImageType = employee.ImageType;
                    employeeProfilePic.Thumbnail = employee.Thumbnail;
                    employeeProfilePic.EmployeeId = employee.Id;
                    employeeProfilePic.ImageUrl = "localhost";

                    _dbContext.Add(employeeProfilePic);
                    _dbContext.SaveChanges();
                }
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
        public void UpdateEmployeeDetails(Employee emp)
        {
            try
            {
                var existingEmployee = _dbContext.Employees.Include(e => e.EmployeeProfilePics).FirstOrDefault(x => x.Id == emp.Id);
                if (existingEmployee != null)
                {
                    existingEmployee.Code = emp.Code;
                    existingEmployee.StartingDate = emp.StartingDate;
                    existingEmployee.FullName = emp.FirstName + " " + emp.LastName;
                    existingEmployee.Address = emp.Address;
                    existingEmployee.City = emp.City;  
                    existingEmployee.State = emp.State;
                    existingEmployee.Country =  emp.Country;
                    existingEmployee.PostalCode = emp.PostalCode;
                    existingEmployee.FirstName = emp.FirstName;
                    existingEmployee.MiddleName = emp.MiddleName;
                    existingEmployee.LastName = emp.LastName; 
                    existingEmployee.Dob = emp.Dob;
                    existingEmployee.PhoneNo = emp.PhoneNo;
                    existingEmployee.EmailAddress = emp.EmailAddress;
                    if(existingEmployee.EmployeeProfilePics.Count > 0) // update image
                    {
                        var existingEmpPic = existingEmployee.EmployeeProfilePics.First();

                        existingEmpPic.Id = emp.EmployeeProfilePicId > 0 ? (int)emp.EmployeeProfilePicId : 0;
                        existingEmpPic.ImageType = emp.ImageType;
                        existingEmpPic.Thumbnail = emp.Thumbnail;
                        existingEmpPic.EmployeeId = emp.Id;
                        existingEmpPic.ImageUrl = "localhost";

                    }
                }
                _dbContext.Update(existingEmployee);
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
                var _data = (from emp in _dbContext.Employees
                                  join pic in this._dbContext.EmployeeProfilePics on emp.Id equals pic.EmployeeId into p
                                  from pic in p.DefaultIfEmpty()
                                  where (emp.Id.Equals(id))
                                  select new Employee
                                  {
                                      Id = emp.Id,
                                      Code = emp.Code,
                                      FullName = emp.FullName,
                                      FirstName = emp.FirstName,
                                      LastName = emp.LastName,
                                      Dob = emp.Dob,
                                      Address = emp.Address,
                                      City = emp.City,
                                      PostalCode = emp.PostalCode,
                                      State = emp.State,
                                      Country = emp.Country,
                                      EmailAddress = emp.EmailAddress,
                                      PhoneNo = emp.PhoneNo,
                                      StartingDate = emp.StartingDate,
                                      ImageType = pic.ImageType,
                                      Thumbnail = pic.Thumbnail,
                                      EmployeeProfilePicId = pic.Id
                                  }).FirstOrDefault();


                return _data;

                if (_data != null)
                {
                    return _data;
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
        public void DeleteEmployee(int empId)
        {
            try
            {
                Employee? emp = _dbContext.Employees
                    .Include(e => e.EmployeeProfilePics)
                    .Where(e => e.Id == empId)
                    .FirstOrDefault();

                if (emp != null)
                {
                    _dbContext.Employees.Remove(emp);
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
