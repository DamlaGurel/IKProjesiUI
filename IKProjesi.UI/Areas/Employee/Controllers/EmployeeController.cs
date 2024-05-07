using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.Enums;
using IKProjesi.UI.Models.VMs.EmployeeVMs;
using IKProjesi.UI.Services.Employee;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Reflection;
using IKProjesi.UI.Models.VMs.ExpenseVMs;
using IKProjesi.UI.Models.VMs.AdvancePaymentVMs;
using IKProjesi.UI.Models.VMs.OffDayVMs;

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
        public IActionResult CreateExpense()
        {
            ViewBag.ExpenseTypes = Enum.GetValues<ExpenseType>();
            ViewBag.MoneyType = Enum.GetValues<MoneyType>();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(CreateExpenseVM createExpense)
        {
            await _employeeService.CreateExpense(createExpense);
            return RedirectToAction(nameof(CreateExpense));
        }

        [HttpGet]
        public IActionResult CreateAdvancePayment()
        {
            ViewBag.AdvanceType = Enum.GetValues<AdvanceType>();
            ViewBag.MoneyType = Enum.GetValues<MoneyType>();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdvancePayment(CreateAdvancePaymentVM createAdvancePayment)
        {
            await _employeeService.CreateAdvancePayment(createAdvancePayment);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> ListAdvancePayment()
        {
            ViewBag.AdvanceType = Enum.GetValues<AdvanceType>();
            ViewBag.MoneyType = Enum.GetValues<MoneyType>();
            ViewBag.ApprovalType = Enum.GetValues<ApprovalType>();
            var advance = await _employeeService.AdvancePayments();
            return View(advance);
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

        //�zin ��lemleri
        [HttpGet]
        public IActionResult CreateOffDay()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOffDay(CreateOffDayVM model)
        {
            await _employeeService.CreateOffDay(model);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id); 

            //string imageString = null;

            //if (employee != null && employee.ImageBytes != null)
            //{
            //    imageString = Convert.ToBase64String(employee.ImageBytes);
            //}

            //employee.ImageString = imageString;

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeVM model)
        {
            await _employeeService.UpdateEmployee(model);
            TempData["UpdateMessage"] = "Employee g�ncellendi.";
            return View(model);
        }
        

        [HttpGet]
        public async Task<IActionResult> ListOffDay(int id)

        {
            List<ListOffDayVM> model = await _employeeService.ListOffDay(id);
            return View(model);
        }
    }
}

