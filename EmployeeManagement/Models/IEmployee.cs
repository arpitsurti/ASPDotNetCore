﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public interface IEmployee
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployees();
        Employee Add(Employee emp);
        Employee Update(Employee emp);
        Employee Delete(int id);
    }
}
