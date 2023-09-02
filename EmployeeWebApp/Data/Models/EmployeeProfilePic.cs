using System;
using System.Collections.Generic;

namespace EmployeeWebApp.Data.Models;

public partial class EmployeeProfilePic
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public string? ImageType { get; set; }

    public string Thumbnail { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public virtual Employee? Employee { get; set; }
}
