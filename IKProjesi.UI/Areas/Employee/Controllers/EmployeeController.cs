using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IKProjesi.UI.Services.Employee;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Areas.Emloyee.Controllers
{
    [Area("Employee")]

    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}