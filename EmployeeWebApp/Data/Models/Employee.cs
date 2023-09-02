using System;
using System.Collections.Generic;

namespace EmployeeWebApp.Data.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? FullName { get; set; }

    public DateTime? Dob { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? PostalCode { get; set; }

    public string? EmailAddress { get; set; }

    public string? PhoneNo { get; set; }

    public DateTime? StartingDate { get; set; }

    public virtual ICollection<EmployeeProfilePic> EmployeeProfilePics { get; set; } = new List<EmployeeProfilePic>();
}
