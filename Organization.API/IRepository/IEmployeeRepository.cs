using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Organization.API.Model;

namespace Organization.API.IRepository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(Guid departmentId);
        Task<Employee> GetEmployeeAsync(Guid departmentId, Guid employeeId);
        void AddEmployee(Employee employeeToAdd);
        void UpdateEmployee(Employee employeeToUpdate);
        Task<bool> SaveChangesAsync();
    }
}
