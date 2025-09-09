using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress, StringLength(150)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Department { get; set; }
    }
}
