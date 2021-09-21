using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();
            //modelBuilder.Entity<Employee>().HasData(new Employee { 
            //    id = 1,
            //    department = Department.IT,
            //    email = "arpit@arpit.com",
            //    name = "Arpit1"
            //},
            //new Employee
            //{
            //    id = 2,
            //    department = Department.HR,
            //    email = "test@arpit.com",
            //    name = "Test"
            //});
        }
    }
}
