using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organization.API.Model
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Enter Employee Name")]
        [MaxLength(150, ErrorMessage = "Employee Name should not be more than 150 Characters")]
        public string Name { get; set; }
        
        [MaxLength(10, ErrorMessage = "Contact Number should not be more than 10 Characters")]
        public string ContactNumber { get; set; }

        public int? Salary { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
