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
    public class DepartmentRepository : IDepartmentRepository,IDisposable
    {
        private DataContext _context;

        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> DepartmentExistsAsync(Guid authorId)
        {
            return await _context.Departments.AnyAsync(x => x.Id == authorId);
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentAsync(Guid authorId)
        {
            if (authorId == Guid.Empty)
            {
                throw new ArgumentException(nameof(authorId)); 
            }

            return await _context.Departments.FirstOrDefaultAsync(x => x.Id == authorId);
        }

        public void AddDepartment(Department department)
        {
            if (department == null)
            {
                throw new ArgumentException(nameof(department));
            }

            _context.Departments.Add(department);
        }
        public void UpdateDepartment (Department department)
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
