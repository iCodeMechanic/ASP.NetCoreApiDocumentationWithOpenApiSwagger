using System;
using Microsoft.EntityFrameworkCore;
using Organization.API.Model;

namespace Organization.API.Context 
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // seed the database with dummy data
            modelBuilder.Entity<Department>().HasData(
                new Department()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "H.R.",
                    DepartmentHeadName = "Alisha"
                },
                new Department()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Sales",
                    DepartmentHeadName = "Anika"
                },
                new Department()
                {
                    Id = Guid.Parse("24810dfc-2d94-4cc7-aab5-cdf98b83f0c9"),
                    Name = "Accounts",
                    DepartmentHeadName = "Aayan"
                },
                new Department()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Name = "Marketing",
                    DepartmentHeadName = "Bhuvan"
                }
                );

            // seed the database with dummy data
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                    DepartmentId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "Zara",
                    ContactNumber = "9999988888",
                    Salary = 80000
                },
                new Employee
                {
                    Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                    DepartmentId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "Alex",
                    ContactNumber = "7777788888",
                    Salary = 70000
                },
                new Employee
                {
                    Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                    DepartmentId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Tanvi",
                    ContactNumber = "9898989898",
                    Salary = 75000
                },
                new Employee
                {
                    Id = Guid.Parse("493c3228-3444-4a49-9cc0-e8532edc59b2"),
                    DepartmentId = Guid.Parse("24810dfc-2d94-4cc7-aab5-cdf98b83f0c9"),
                    Name = "Shrishti",
                    ContactNumber = "9396939693",
                    Salary = 65000
                },
                new Employee
                {
                    Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                    DepartmentId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Name = "Anant",
                    ContactNumber = "8787898985",
                    Salary = 74000
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
