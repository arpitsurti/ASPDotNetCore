using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SQLEmployee : IEmployee
    {
        private readonly AppDbContext context;

        public SQLEmployee(AppDbContext context)
        {
            this.context = context;
        }

        public Employee Add(Employee emp)
        {
            context.Employees.Add(emp);
            context.SaveChanges();
            return emp;
        }

        public Employee Delete(int id)
        {
            Employee emp = context.Employees.Find(id);
            if (emp != null)
            {
                context.Employees.Remove(emp);
                context.SaveChanges();
            }
            return emp;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return context.Employees;
        }

        public Employee GetEmployee(int id)
        {
            return context.Employees.Find(id);
        }

        public Employee Update(Employee emp)
        {
            var employee = context.Employees.Attach(emp);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return emp;
        }
    }
}
