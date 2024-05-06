using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.EmployeeVMs;
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

        [HttpGet]
        public async Task<IActionResult> GetEmployeeSummary(int id)
        {
            var employeeSummary = await _employeeService.GetEmployeeSummary(id);

            return View(employeeSummary);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeDetails(int id)
        {
            var employeeDetails = await _employeeService.GetEmployeeDetails(id);
            return View(employeeDetails);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id); 

            string imageString = null;

            if (employee != null && employee.ImageBytes != null)
            {
                imageString = Convert.ToBase64String(employee.ImageBytes);
            }

            employee.ImageString = imageString;
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeVm model)
        {
            await _employeeService.UpdateEmployee(model);
            return RedirectToAction("GetEmployeeDetails");
        }
        public IActionResult CreateTakeOffDay()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult CreateTakeOffDay(int id)
        //{
        //    return View();
        //}
    }
}