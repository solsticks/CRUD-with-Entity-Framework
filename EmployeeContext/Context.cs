using EmployeeClassLibrary;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeContext
{
    public class Context : DbContext // this is my context class
    {
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=EmployeeDB;Trusted_Connection=True;");
        }
    }
}
