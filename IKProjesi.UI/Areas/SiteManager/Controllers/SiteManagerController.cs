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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace IKProjesi.UI.Areas.SiteManager.Controllers
{
    [Area("SiteManager")]
    //[Authorize(AuthenticationSchemes = "Bearer", Roles = "S�TEMANAGER")]
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
        public async Task<IActionResult> GetSiteManagerSummary(int id = 5)
        {
            var siteManagerSummary = await _siteManagerService.GetSiteManagerSummary(id);
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> GetSiteManagerDetail(int id = 5)
        {
            var siteManagerDetail = await _siteManagerService.SiteManagerDetails(id);
            return View(siteManagerDetail);
        }


        [HttpGet]
        public IActionResult GetSiteManagerUpdate(int id = 5)
        {
            var siteManagerUpdate = new SiteManagerUpdateVM { Id = id };
            return View(siteManagerUpdate);
        }


        [HttpPost]
        public async Task<IActionResult> GetSiteManagerUpdate(SiteManagerUpdateVM siteManagerUpdateVM)
        {
            siteManagerUpdateVM.Id = 5;
            await _siteManagerService.GetSiteManagerUpdate(siteManagerUpdateVM);
            return RedirectToAction("GetSiteManagerDetail");
        }



        [HttpGet]
        public async Task<IActionResult> AddCompanyManager()
        {
            CompanyManagerCompanyVm model = new CompanyManagerCompanyVm
            {
                     Companies= await _companyService.GetCompanies(),

                };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCompanyManager(CompanyManagerCompanyVm model,int companyId)
        {
            model.CreateCompanyManagerVm.CompanyId = companyId;

            var vm=model.CreateCompanyManagerVm;
            //var vm = model.CreateCompanyManagerVm;

            //CreateCompanyManagerVm cm = new CreateCompanyManagerVm
            //{
            //    CompanyId = companyId,
            //    CreateCompanyManagerVm = vm,

            //};
            //model.CreateCompanyManagerVm.CompanyId = companyId;
            


            await _companyManagerService.CreateCompanyManager(vm);

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
        public async Task<IActionResult> CreateCompany(CreateCompanyVM model)
        {
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