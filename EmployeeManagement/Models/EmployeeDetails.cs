using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeDetails : IEmployee
    {
        List<Employee> lstEmp;
        public EmployeeDetails()
        {
            lstEmp = new List<Employee>();
            lstEmp.Add(new Employee() { id = 1, department = Department.IT, email = "arpit@gmail.com", name = "Arpit" });
            lstEmp.Add(new Employee() { id = 2, department = Department.Accounting, email = "arpit2@gmail.com", name = "Arpit2" });
            lstEmp.Add(new Employee() { id = 3, department = Department.IT, email = "arpit3@gmail.com", name = "Arpit3" });
            lstEmp.Add(new Employee() { id = 4, department = Department.IT, email = "arpit4@gmail.com", name = "Arpit4" });
        }

        public Employee Add(Employee emp)
        {
            emp.id = lstEmp.Max(x => x.id) + 1;
            lstEmp.Add(emp);
            return emp;
        }

        public Employee Delete(int id)
        {
            Employee emp = lstEmp.FirstOrDefault(e=>e.id == id);
            if (emp != null)
            {
                lstEmp.Remove(emp);
            }
            return emp;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return lstEmp;
        }

        public Employee GetEmployee(int id)
        {
            return lstEmp.FirstOrDefault(x => x.id == id);
        }

        public Employee Update(Employee empUpdated)
        {
            Employee emp = lstEmp.FirstOrDefault(e => e.id == empUpdated.id);
            if (emp != null)
            {
                emp.name = emp.name;
                emp.department = emp.department;
                emp.email = emp.email;
            }
            return emp;
        }
    }
}
