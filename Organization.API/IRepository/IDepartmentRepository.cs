using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Organization.API.Model;

namespace Organization.API.IRepository
{
   public interface IDepartmentRepository
    {
        Task<bool> DepartmentExistsAsync(Guid departmentId);

        Task<IEnumerable<Department>> GetDepartmentsAsync();

        Task<Department> GetDepartmentAsync(Guid departmentId);

        void AddDepartment(Department department);
        void UpdateDepartment(Department department);

        Task<bool> SaveChangesAsync();
    }
}
