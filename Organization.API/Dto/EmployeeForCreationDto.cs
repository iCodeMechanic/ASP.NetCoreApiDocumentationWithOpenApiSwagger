using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organization.API.Dto
{
    public class EmployeeForCreationDto
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public int? Salary { get; set; }
    }
}
