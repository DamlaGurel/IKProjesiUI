using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Services.CompanyManager;
using IKProjesi.UI.Services.SiteManager;

using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Areas.SiteManager.Controllers
{

    [Area("SiteManager")]
    public class SiteManagerController : Controller
    {
        private readonly ISiteManagerService _siteManagerService;
        private readonly ICompanyManagerService _companyManagerService;


        public SiteManagerController(ISiteManagerService siteManagerService, ICompanyManagerService companyManagerService)
        {
            _siteManagerService = siteManagerService;
            _companyManagerService = companyManagerService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetSiteManagerSummary(int id = 1)
        public async Task<IActionResult> CompanyManagerList()
        {
            var companyManagers = await _companyManagerService.GetCompanyManagers();
            return View(companyManagers);
        }


        //[HttpGet]
        //public async Task<IActionResult> AddCompanyManager()
        //{
        //    return View();
        //}

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

    }
}