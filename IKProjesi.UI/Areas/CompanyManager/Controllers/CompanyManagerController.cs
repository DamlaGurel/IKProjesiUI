using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.EmployeeVMs;
using IKProjesi.UI.Services.CompanyManager;
using IKProjesi.UI.Services.Employee;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Areas.CompanyManager.Controllers
{
    [Area("CompanyManager")]
    public class CompanyManagerController : Controller
    {
        private readonly ICompanyManagerService _companyManagerService;
        private readonly IEmployeeService _employeeService;

        public CompanyManagerController(ICompanyManagerService companyManagerService, IEmployeeService employeeService)
        {
            _companyManagerService = companyManagerService;
            _employeeService = employeeService;
        }

        
        public IActionResult Index()
        {
            return View(); 
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyManagerSummary(int id)
        {
            /*https://localhost:7023/CompanyManager/CompanyManager/GetCompanyManagerSummary*/
            var companyManagerSummary = await _companyManagerService.GetCompanyManagerSummary(id);
            return View(companyManagerSummary);

        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyManagerDetail(int id)
        {
            var companyManagerDetail = await _companyManagerService.GetCompanyManagerDetails(id);
            return View(companyManagerDetail);
        }


        [HttpGet]
        public async Task<IActionResult> GetCompanyManagerUpdate(int id)
        {
            //var companyManagerUpdate = new UpdateCompanyManagerVm { Id = id };

            var companyManagerUpdate = await _companyManagerService.GetCompanyManagerById(id);

            string imageString = null;

            //if (companyManagerUpdate != null && companyManagerUpdate.ImageBytes != null)
            //{
            //    imageString = Convert.ToBase64String(companyManagerUpdate.ImageBytes);
            //}

            //companyManagerUpdate.ImageString = imageString;
            return View(companyManagerUpdate);
        }


        [HttpPost]
        public async Task<IActionResult> GetCompanyManagerUpdate(UpdateCompanyManagerVM companyManagerUpdateVM)
        {


            await _companyManagerService.GetCompanyManagerUpdate(companyManagerUpdateVM);
            return RedirectToAction("GetCompanyManagerDetail");
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeVM model)
        {
            await _employeeService.CreateEmployee(model);

            return RedirectToAction(nameof(Index));
        }


        //İzin İşlemleri
        [HttpGet]
        public async Task<IActionResult> ListApprovalForOffDay()
        {
            var listApprovalForOffDay = await _companyManagerService.ListApprovalForOffDay();

            return View(listApprovalForOffDay);
        }

        


        [HttpPost]
        public async Task<IActionResult> GetApprovalForOffDay(UpdateDayOffVm model)
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
    }
}
