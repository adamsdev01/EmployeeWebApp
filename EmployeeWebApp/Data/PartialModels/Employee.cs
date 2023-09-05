using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeWebApp.Data.Models
{
    public partial class Employee
    {
        [NotMapped]
        public int? EmployeeProfilePicId { get; set; }

        [NotMapped]
        public string? Thumbnail { get; set; }

        [NotMapped]
        public string? ImageType { get; set; }

    }
}
