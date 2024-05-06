using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        

        [HttpGet]
        public IActionResult CreateExpense()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(CreateExpenseVM createExpense)
        {
            await _employeeService.CreateExpense(createExpense);
            return RedirectToAction(nameof(CreateExpense));
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

