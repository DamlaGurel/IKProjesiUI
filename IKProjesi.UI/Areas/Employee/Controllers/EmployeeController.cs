
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
        public IActionResult CreateAdvancePayment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdvancePayment(CreateAdvancePaymentVM createAdvancePayment)
        {
            await _employeeService.CreateAdvancePayment(createAdvancePayment);
            return RedirectToAction(nameof(CreateAdvancePayment));
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

        
        public IActionResult CreateTakeOffDay()
        {
            return View();
        }


        //İzin İşlemleri
        [HttpGet]
        public IActionResult CreateTakeDayOff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTakeDayOff(CreateOffDayVm model)
        {
            await _employeeService.CreateTakeDayOff(model);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListTakeDayOff(int id)

        {
            List<ListOffDaysVm> model = await _employeeService.ListTakeDayOff(id);
            return View(model);
        }



       


    }
}

