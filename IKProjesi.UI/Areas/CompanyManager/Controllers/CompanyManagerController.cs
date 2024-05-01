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
        public async Task<IActionResult> GetCompanyManagerUpdate(UpdateCompanyManagerVm companyManagerUpdateVM)
        {


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
