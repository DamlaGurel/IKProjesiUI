using IKProjesi.UI.Models.VMs.CompanyVMs;
using IKProjesi.UI.Services.Company;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        public async Task<IActionResult> Index()
        {
            var companies = await _companyService.GetCompanies();
            return View(companies);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyVM model)
        {
           await _companyService.CreateCompany(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
           var company= await _companyService.GetCompanyDetails(id);
            return View(company);
        }

    }
}
