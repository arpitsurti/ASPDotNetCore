﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }

        public string email { get; set; }
        public Department department { get; set; }
    }
}
