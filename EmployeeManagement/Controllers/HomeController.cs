using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployee _iEmployee;
        private readonly ILogger<HomeController> logger;

        public HomeController(IEmployee emp,ILogger<HomeController> logger)
        {
            _iEmployee = emp;
            this.logger = logger;
        }
        public ViewResult Index()
        {
            return View(_iEmployee.GetAllEmployees());
        }

        public ViewResult Details(int id)
        {
            //throw new Exception("Error in details view");
            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");
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
