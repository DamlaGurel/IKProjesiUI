using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IKProjesi.UI.Models.Enums;
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

        [HttpGet]
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
            //if (createExpense.File.ContentType == "application/pdf" || createExpense.File.ContentType == "image/png" || createExpense.File.ContentType == "image/jpeg")
            //{
            await _employeeService.CreateExpense(createExpense);

            //    // File i�leme i�lemi tamamland�ktan sonra API tarz�nda bir ��kt� olu�turun
            //    return Ok(new { basarili = true, mesaj = "File ba�ar�yla y�klendi!" });
            //}
            //else
            //{
            //    // Yaln�zca PDF, PNG veya JPEG dosyalar� kabul edilir.
            //    return BadRequest(new { basarili = false, mesaj = "Yaln�zca PDF, PNG veya JPEG dosyalar� kabul edilir." });
            //}

            return RedirectToAction(nameof(CreateExpense));
        }

    }
}