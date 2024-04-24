using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.CompanyVMs;
using IKProjesi.UI.Services.Company;
using IKProjesi.UI.Services.CompanyManager;
using IKProjesi.UI.Services.SiteManager;

using Microsoft.AspNetCore.Mvc;
using Refit;

namespace IKProjesi.UI.Areas.SiteManager.Controllers
{
    [Area("SiteManager")]
    public class SiteManagerController : Controller
    {
        private readonly ISiteManagerService _siteManagerService;
        private readonly ICompanyManagerService _companyManagerService;
        private readonly ICompanyService _companyService;



        public SiteManagerController(ISiteManagerService siteManagerService, ICompanyManagerService companyManagerService, ICompanyService companyService)
        {
            _siteManagerService = siteManagerService;
            _companyManagerService = companyManagerService;
            _companyService = companyService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CompanyManagerList()
        {
            var companyManagers = await _companyManagerService.GetCompanyManagers();
            return View(companyManagers);
        }



        public async Task<IActionResult> AddCompanyManager()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCompanyManager([FromBody] CreateCompanyManagerVm model)
        {
            await _companyManagerService.CreateCompanyManager(model);
            return RedirectToAction(nameof(CompanyManagerList));
        }

        //public async Task<IActionResult> GetSiteManagerSummary(int id = 1)
        //{
        //    var siteManagerSummary = await _siteManagerService.GetSiteManagerSummary(id);
        //    return View(siteManagerSummary);

        //}

      
       
        public async Task<IActionResult> CompanyIndex()
        {
            var companies = await _companyService.GetCompanies();
            return View(companies);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
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
            var company = await _companyService.GetCompanyDetails(id);
            return View(company);
        }

    }
}