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
        public async Task<IActionResult> CreateAdvancePayment()
        {
            CreateAdvancePaymentVM createAdvancePayment = new CreateAdvancePaymentVM();
            createAdvancePayment.EmployeeId = HttpContext.Session.GetInt32("UserId") ?? 0;
            createAdvancePayment.Payment = await _employeeService.TotalAdvancePayment(createAdvancePayment.EmployeeId);
            ViewBag.AdvanceType = Enum.GetValues<AdvanceType>();
            ViewBag.MoneyType = Enum.GetValues<MoneyType>();
            return View(createAdvancePayment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdvancePayment(CreateAdvancePaymentVM createAdvancePayment)
        {
            if (createAdvancePayment != null && ModelState.IsValid)
            {
                createAdvancePayment.EmployeeId = HttpContext.Session.GetInt32("UserId") ?? 0;
                await _employeeService.TotalAdvancePayment(createAdvancePayment.EmployeeId);
                await _employeeService.CreateAdvancePayment(createAdvancePayment);
                TempData["Success"] = "Avans talebiniz yöneticinize gönderildi.";
                return RedirectToAction(nameof(GetEmployeeSummary));
            }
            ViewBag.AdvanceType = Enum.GetValues<AdvanceType>();
            ViewBag.MoneyType = Enum.GetValues<MoneyType>();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListAdvancePayment()
        {
            int Id = HttpContext.Session.GetInt32("UserId") ?? 0;
            ViewBag.AdvanceType = Enum.GetValues<AdvanceType>();
            ViewBag.MoneyType = Enum.GetValues<MoneyType>();
            ViewBag.ApprovalType = Enum.GetValues<ApprovalType>();
            var advance = await _employeeService.ListAdvancePayment(Id);
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
        public async Task<IActionResult> GetEmployeeSummary()
        {
            int Id = HttpContext.Session.GetInt32("UserId") ?? 0;
            var employeeSummary = await _employeeService.GetEmployeeSummary(Id);
            return View(employeeSummary);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeDetails()
        {
            int Id = HttpContext.Session.GetInt32("UserId") ?? 0;
            var employeeDetails = await _employeeService.GetEmployeeDetails(Id);
            return View(employeeDetails);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee()
        {
            int Id = HttpContext.Session.GetInt32("UserId") ?? 0;
            var employee = await _employeeService.GetEmployeeById(Id);
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

