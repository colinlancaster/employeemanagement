using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        // Injected via the constructor
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        //[Route("")]
        // using tokens like "action" is powerful
        // It gives you flexibility to change the name of your route,
        // without worrying about updating the route attribute value.
        //[Route("[action]")]
        //[Route("~/")]
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees();
            return View(model);
        }

        //[Route("{id?}")]
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                // Null Coalescing Operator.
                // If the incoming param is not null, use id.
                // If the incoming param is null, use 1.
                Employee = _employeeRepository.GetEmployee(id ?? 1),
                PageTitle = "Employee Details",
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(employee);
                //return RedirectToAction("details", new { id = newEmployee.Id });
            }

            return View();
        }
    }
}
