using IKProjesi.UI.Models.Enums;
using IKProjesi.UI.Models.VMs.AdvancePaymentVMs;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.EmployeeVMs;
using IKProjesi.UI.Models.VMs.ExpenseVMs;
using IKProjesi.UI.Models.VMs.OffDayVMs;
using IKProjesi.UI.Services.CompanyManager;
using IKProjesi.UI.Services.Employee;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace IKProjesi.UI.Areas.CompanyManager.Controllers
{
    [Area("CompanyManager")]
    public class CompanyManagerController : Controller
    {
        private readonly ICompanyManagerService _companyManagerService;
        private readonly IEmployeeService _employeeService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CompanyManagerController(ICompanyManagerService companyManagerService, IEmployeeService employeeService, IHttpContextAccessor httpContextAccessor)
        {
            _companyManagerService = companyManagerService;
            _employeeService = employeeService;
            _httpContextAccessor = httpContextAccessor;
        }


        public IActionResult Index()
        {
            return View();
        }

        #region Company Manager 
        [HttpGet]
        public async Task<IActionResult> GetCompanyManagerSummary()
        {
            int Id = HttpContext.Session.GetInt32("UserId") ?? 0;
            var companyManagerSummary = await _companyManagerService.GetCompanyManagerSummary(Id);
            return View(companyManagerSummary);

        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyManagerDetail()
        {
            int Id = HttpContext.Session.GetInt32("UserId") ?? 0;
            var companyManagerDetail = await _companyManagerService.GetCompanyManagerDetails(Id);
            return View(companyManagerDetail);
        }


        [HttpGet]
        public async Task<IActionResult> GetCompanyManagerUpdate()
        {
            int Id = HttpContext.Session.GetInt32("UserId") ?? 0;
            var companyManagerUpdate = await _companyManagerService.GetCompanyManagerById(Id);
            return View(companyManagerUpdate);
        }


        [HttpPost]
        public async Task<IActionResult> GetCompanyManagerUpdate(UpdateCompanyManagerVM companyManagerUpdateVM)
        {
            var companyManager = await _companyManagerService.GetCompanyManagerUpdate(companyManagerUpdateVM);
            TempData["UpdateMessage"] = "Profil güncellendi.";
            return View(companyManager);
        }
        #endregion

        #region Employee
        [HttpGet]
        public IActionResult CreateEmployee()
        {
            CreateEmployeeVM employee = new CreateEmployeeVM();
            employee.CompanyManagerId = HttpContext.Session.GetInt32("UserId") ?? 0;
            ViewBag.Department = Enum.GetValues<Department>();
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeVM model)
        {
            ViewBag.Department = Enum.GetValues<Department>();
            model.CompanyManagerId = HttpContext.Session.GetInt32("UserId") ?? 0;
            if (ModelState.IsValid)
            {
                await _employeeService.CreateEmployee(model);
                TempData["Success"] = "Personel eklendi";
                return RedirectToAction(nameof(GetCompanyManagerSummary));
            }
            return View();
        }
        #endregion

        #region Off Day
        [HttpGet]
        public async Task<IActionResult> ListApprovalForOffDay()
        {
            var listApprovalForOffDay = await _companyManagerService.ListApprovalForOffDay();

            return View(listApprovalForOffDay);
        }

        [HttpPost]
        public async Task<IActionResult> GetApprovalForOffDay(UpdateOffDayVM model)
        {
            await _companyManagerService.GetApprovalForOffDay(model);
            return RedirectToAction(nameof(ListApprovalForOffDay));
        }

        [HttpGet]
        public async Task<IActionResult> GetApprovalForOffDay(int id)
        {
            var getApprovalForOffDay = await _companyManagerService.GetApprovalForOffDay(id);
            return View(getApprovalForOffDay);
        }
        #endregion

        #region Expense
        [HttpGet]
        public async Task<IActionResult> ListApprovalForExpense()
        {
            int Id = HttpContext.Session.GetInt32("UserId") ?? 0;
            var listApprovalForExpense = await _companyManagerService.ListApprovalForExpense(Id);
            return View(listApprovalForExpense);
        }

        [HttpPost]
        public async Task<IActionResult> GetApprovalForExpense(UpdateExpenseVM model)
        {
            await _companyManagerService.GetApprovalForExpense(model);
            return RedirectToAction(nameof(ListApprovalForExpense));
        }

        [HttpGet]
        public async Task<IActionResult> GetApprovalForExpense(int id)
        {
            var getApprovalForExpense = await _companyManagerService.GetApprovalForExpense(id);
            return View(getApprovalForExpense);
        }
        #endregion

        #region Advance Payment

        [HttpGet]
        public async Task<IActionResult> ListApprovalForAdvancePayment()
        {
            int Id = HttpContext.Session.GetInt32("UserId") ?? 0;
            var listApprovalForAdvancePayment = await _companyManagerService.ListApprovalForAdvancePayment(Id);
            return View(listApprovalForAdvancePayment);
        }

        [HttpGet]
        public async Task<IActionResult> GetApprovalForAdvancePayment()
        {
            int Id = HttpContext.Session.GetInt32("UserId") ?? 0;
            var getApprovalForAdvancePayment = await _companyManagerService.GetApprovalForAdvancePayment(Id);
            return View(getApprovalForAdvancePayment);
        }

        [HttpPost]
        public async Task<IActionResult> GetApprovalForAdvancePayment(UpdateAdvancePaymentVM model)
        {
            model.EmployeeId = HttpContext.Session.GetInt32("UserId") ?? 0;
            await _companyManagerService.GetApprovalForAdvancePayment(model);
            return RedirectToAction(nameof(ListApprovalForAdvancePayment));
        }

        
        #endregion
    }
}
