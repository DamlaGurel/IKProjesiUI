using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.CompanyVMs;
using IKProjesi.UI.Models.VMs.SiteManagerVMs;
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

        [HttpGet]
        public async Task<IActionResult> GetSiteManagerSummary(int id = 40)
        {
            var siteManagerSummary = await _siteManagerService.GetSiteManagerSummary(id);
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> GetSiteManagerDetail(int id)
        {
            var siteManagerDetail = await _siteManagerService.SiteManagerDetails(id);
            return View(siteManagerDetail);
        }


        [HttpGet]
        public IActionResult GetSiteManagerUpdate(int id)
        {
            var siteManagerUpdate = new SiteManagerUpdateVM { Id = id };
            return View(siteManagerUpdate);
        }


        [HttpPost]
        public async Task<IActionResult> GetSiteManagerUpdate(SiteManagerUpdateVM siteManagerUpdateVM)
        {
            await _siteManagerService.GetSiteManagerUpdate(siteManagerUpdateVM);
            return RedirectToAction("GetSiteManagerSummary");
        }

        //[HttpGet]
        //public async Task<IActionResult> AddCompanyManager()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult AddCompanyManager()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCompanyManager(CreateCompanyManagerVm model)
        {
            await _companyManagerService.CreateCompanyManager(model);
            return RedirectToAction(nameof(CompanyManagerList));
        }

        public async Task<IActionResult> CompanyIndex()
        {
            var companies = await _companyService.GetCompanies();
            return View(companies);
        }


        [HttpGet]
        public async Task<IActionResult> CreateCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyVM model)
        {
            if (model.Logo is not null)
            {
                await _companyService.SaveLogo(model.Logo);
            }

            await _companyService.CreateCompany(model);
            return RedirectToAction(nameof(CompanyIndex));
        }

        [HttpGet]
        public async Task<IActionResult> CompanyDetails(int id)
        {
            var company = await _companyService.GetCompanyDetails(id);
            return View(company);
        }



    }
}