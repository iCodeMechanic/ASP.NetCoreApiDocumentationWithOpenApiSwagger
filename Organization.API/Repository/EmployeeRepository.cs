using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Organization.API.Context;
using Organization.API.IRepository;
using Organization.API.Model;

namespace Organization.API.Repository
{
    public class EmployeeRepository : IEmployeeRepository,IDisposable
    {
        private DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid departmentId)
        {
            if (departmentId == Guid.Empty)
            {
                throw new ArgumentException(nameof(departmentId));
            }

            return await _context.Employees.Include(e => e.Department)
                .Where(e => e.DepartmentId == departmentId)
                .ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(Guid departmentId, Guid employeeId)
        {
            if (departmentId == Guid.Empty)
            {
                throw new ArgumentException(nameof(departmentId));
            }

            if (employeeId == null)
            {
                throw new ArgumentException(nameof(employeeId));
            }

            return await _context.Employees.Include(e => e.Department)
                .Where(e => e.DepartmentId == departmentId && e.Id == employeeId)
                .FirstOrDefaultAsync();
        }

        public void AddEmployee(Employee employeeToAdd)
        {
            if (employeeToAdd == null)
            {
                throw new ArgumentException(nameof(employeeToAdd));
            }

            _context.Add(employeeToAdd);
        }
        public void UpdateEmployee(Employee employeeToUpdate)
        {
            // no code in this implementation
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
