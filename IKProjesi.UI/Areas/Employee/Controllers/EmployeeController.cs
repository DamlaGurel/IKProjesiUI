using IKProjesi.UI.Models.Enums;
using IKProjesi.UI.Models.VMs.EmployeeVMs;
using IKProjesi.UI.Services.Employee;
using Microsoft.AspNetCore.Mvc;
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

        #region Expense

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
        public async Task<IActionResult> ListExpense(int id)
        {
            ViewBag.ExpenseTypes = Enum.GetValues<ExpenseType>();
            ViewBag.MoneyType = Enum.GetValues<MoneyType>();
            List<ListExpenseVM> expense = await _employeeService.ListExpense(id);
            return View(expense);
        }

        #endregion

        #region Advance
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
            if (createAdvancePayment != null && ModelState.IsValid)
            {
                await _employeeService.CreateAdvancePayment(createAdvancePayment);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.AdvanceType = Enum.GetValues<AdvanceType>();
            ViewBag.MoneyType = Enum.GetValues<MoneyType>();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListAdvancePayment(int id)
        {
            ViewBag.AdvanceType = Enum.GetValues<AdvanceType>();
            ViewBag.MoneyType = Enum.GetValues<MoneyType>();
            ViewBag.ApprovalType = Enum.GetValues<ApprovalType>();
            var advance = await _employeeService.ListAdvancePayment(id);
            return View(advance);
        }
        #endregion

        #region OffDay
        [HttpGet]
        public IActionResult CreateOffDay()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOffDay(CreateOffDayVM model)
        {
            await _employeeService.CreateOffDay(model);
            TempData["Success"] = "İzin talebi oluşturuldu";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListOffDay(int id)
        {
            List<ListOffDayVM> model = await _employeeService.ListOffDay(id);
            return View(model);
        }
        #endregion

        #region Employee
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
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeVM model)
        {
            var employee = await _employeeService.UpdateEmployee(model);
            TempData["UpdateMessage"] = "Employee güncellendi.";
            return View(employee);
        }
        #endregion



    }
}

