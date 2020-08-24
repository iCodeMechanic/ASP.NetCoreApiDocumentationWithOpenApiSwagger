using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organization.API.Model
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Enter Department Name")]
        [MaxLength(150,ErrorMessage = "Department Name should not be more than 150 Characters")]
        
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Department Name")]
        [MaxLength(150, ErrorMessage = "Department Name should not be more than 150 Characters")]
        
        public string DepartmentHeadName { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
