using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployee _iEmployee;
        public HomeController(IEmployee emp)
        {
            _iEmployee = emp;
        }
        public ViewResult Index()
        {
            return View(_iEmployee.GetAllEmployees());
        }

        public ViewResult Details(int id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _iEmployee.GetEmployee(id),
                PageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        }

        public ViewResult Create()
        {
            return View();
        }

        public ViewResult Edit(int id)
        {
            Employee _emp= _iEmployee.GetEmployee(id);
            return View(_emp);
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                Employee newEmp = _iEmployee.Add(emp);
                return RedirectToAction("details", new { id = newEmp.id });
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                Employee newEmp = _iEmployee.Update(emp);
                return RedirectToAction("details", new { id = newEmp.id });
            }
            return View();
        }
    }
}
