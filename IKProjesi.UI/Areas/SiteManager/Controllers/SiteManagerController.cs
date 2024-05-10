using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IKProjesi.UI.Models;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.CompanyVMs;
using IKProjesi.UI.Models.VMs.Pagination;
using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using IKProjesi.UI.Services.Company;
using IKProjesi.UI.Services.CompanyManager;
using IKProjesi.UI.Services.SiteManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;

namespace IKProjesi.UI.Areas.SiteManager.Controllers
{
    [Area("SiteManager")]
    //[Authorize(AuthenticationSchemes = "Bearer", Roles = "SITEMANAGER")]
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

        public async Task<IActionResult> CompanyManagerList(int pg = 1)
        {
            var companyManagers = await _companyManagerService.GetCompanyManagers();

            //Pagination:
            const int pageSize = 12;
            if (pg < 1)
            {
                pg = 1;
            }

            int recsCount = companyManagers.Count();

            var pager = new PaginationParams(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = companyManagers.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetSiteManagerSummary(int id)
        {
            var siteManagerSummary = await _siteManagerService.GetSiteManagerSummary(id);
            return View(siteManagerSummary);

        }

        [HttpGet]
        public async Task<IActionResult> GetSiteManagerDetail(int id)
        {
            var siteManagerDetail = await _siteManagerService.SiteManagerDetails(id);
            return View(siteManagerDetail);
        }


        [HttpGet]
        public async Task<IActionResult> GetSiteManagerUpdate(int id)
        {
            var siteManagerUpdate = await _siteManagerService.GetSiteManagerById(id);
            return View(siteManagerUpdate);
        }


        [HttpPost]
        public async Task<IActionResult> GetSiteManagerUpdate(SiteManagerUpdateVM siteManagerUpdateVM)
        {
            var siteManager= await _siteManagerService.GetSiteManagerUpdate(siteManagerUpdateVM);
            TempData["UpdateMessage"] = "Site manager güncellendi.";
            return View(siteManager);
        }



        [HttpGet]
        public async Task<IActionResult> CreateCompanyManager()
        {
            CompanyManagerCompanyVM model = new CompanyManagerCompanyVM
            {
                Companies = await _companyService.GetCompanies(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompanyManager(CompanyManagerCompanyVM model, int companyId)
        {

            //if (ModelState.IsValid)
            //{
                model.CreateCompanyManagerVM.CompanyId = companyId;

                var vm = model.CreateCompanyManagerVM;

                await _companyManagerService.CreateCompanyManager(vm);

                return RedirectToAction(nameof(CompanyManagerList));
            //}

            //else
            //{
            //    if (string.IsNullOrEmpty(model.CreateCompanyManagerVm.FirstName))
            //{
            //    ModelState.AddModelError(nameof(model.CreateCompanyManagerVm.FirstName), "Lütfen adınızı giriniz.");
            //}


            //if (string.IsNullOrEmpty(model.CreateCompanyManagerVm.LastName))
            //{
            //    ModelState.AddModelError(nameof(model.CreateCompanyManagerVm.LastName), "Lütfen soyadınızı giriniz.");
            //}

            //    return View();
            //}
           // return View();
        }

        public async Task<IActionResult> CompanyIndex(int pg = 1)
        {
            var companies = await _companyService.GetCompanies();

            //Pagination:
            const int pageSize = 12;
            if (pg < 1)
            {
                pg = 1;
            }

            int recsCount = companies.Count();

            var pager = new PaginationParams(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = companies.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);

        }


        [HttpGet]
        public IActionResult CreateCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyVM model)
        {
            if (ModelState.IsValid)
            {
                await _companyService.CreateCompany(model);
                return RedirectToAction(nameof(CompanyIndex));
            }
            return View();
            
        }

        [HttpGet]
        public async Task<IActionResult> CompanyDetails(int id)
        {
            var company = await _companyService.GetCompanyDetails(id);
            return View(company);
        }



    }
}