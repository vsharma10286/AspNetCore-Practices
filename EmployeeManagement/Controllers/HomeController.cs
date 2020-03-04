using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

       
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ViewResult Index()
        {
            var model= _employeeRepository.GetAllEmployees();
            return View(model);
        }

        [Route("Home/Details/{id?}")]
        public ViewResult Details(int? id)
        {
            Employee model = _employeeRepository.GetEmployee(id??1);
            HomeDetailsViewModel employee = new HomeDetailsViewModel();
            employee.Employee = model;
            employee.PageTitle = "Employee Details";
           // ViewData["Employee"] = model;
            return View(employee);
        }

        public ViewResult Create()
        {
            return View();
        }
    }
}