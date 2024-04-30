using IKProjesi.UI.Models.VMs.CompanyManagerVMs;using IKProjesi.UI.Models.VMs.PersonelVMs;
using IKProjesi.UI.Services.CompanyManager;
using IKProjesi.UI.Services.Personel;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Areas.CompanyManager.Controllers
{
    [Area("CompanyManager")]
    public class CompanyManagerController : Controller
    {
        private readonly ICompanyManagerService _companyManagerService;
        private readonly IPersonelService _personelService;

        public CompanyManagerController(ICompanyManagerService companyManagerService, IPersonelService personelService)
        {
            _companyManagerService = companyManagerService;
            _personelService = personelService;
        }

        
        public IActionResult Index()
        {
            return View(); 
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyManagerSummary(int id = 22)
        {
            /*https://localhost:7023/CompanyManager/CompanyManager/GetCompanyManagerSummary*/
            var companyManagerSummary = await _companyManagerService.GetCompanyManagerSummary(id);
            return View(companyManagerSummary);

        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyManagerDetail(int id = 22)
        {
            var companyManagerDetail = await _companyManagerService.GetCompanyManagerDetails(id);
            return View(companyManagerDetail);
        }


        [HttpGet]
        public IActionResult GetCompanyManagerUpdate(int id = 22)
        {
            var companyManagerUpdate = new UpdateCompanyManagerVm { Id = id };
            return View(companyManagerUpdate);
        }


        [HttpPost]
        public async Task<IActionResult> GetCompanyManagerUpdate(UpdateCompanyManagerVm companyManagerUpdateVM)
        {
            companyManagerUpdateVM.Id = 22;
            await _companyManagerService.GetCompanyManagerUpdate(companyManagerUpdateVM);
            return RedirectToAction("GetCompanyManagerDetail");
        }

        [HttpGet]
        public IActionResult CreatePersonel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonel(CreatePersonelVM model)
        {
            await _personelService.CreatePersonel(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
