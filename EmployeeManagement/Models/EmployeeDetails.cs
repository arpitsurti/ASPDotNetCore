using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeDetails : IEmployee
    {
        List<Employee> emp;
        public EmployeeDetails()
        {
            emp = new List<Employee>();
            emp.Add(new Employee() { id = 1, department = "IT", email = "arpit@gmail.com", name = "Arpit" });
            emp.Add(new Employee() { id = 2, department = "Accounting", email = "arpit2@gmail.com", name = "Arpit2" });
            emp.Add(new Employee() { id = 3, department = "IT", email = "arpit3@gmail.com", name = "Arpit3" });
            emp.Add(new Employee() { id = 4, department = "IT", email = "arpit4@gmail.com", name = "Arpit4" });
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return emp;
        }

        public Employee GetEmployee(int id)
        {
            return emp.FirstOrDefault(x => x.id == id);
        }


    }
}
