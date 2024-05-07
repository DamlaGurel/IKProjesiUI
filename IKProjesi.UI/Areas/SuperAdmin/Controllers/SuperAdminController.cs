using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using IKProjesi.UI.Services.SiteManager;
using IKProjesi.UI.Services.SuperAdmin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using Refit;

namespace IKProjesi.UI.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    public class SuperAdminController : Controller
    {
        private readonly ISiteManagerService _siteManagerService;
        private readonly ISuperAdminService _superAdminService;

        public SuperAdminController(ISiteManagerService siteManagerService, ISuperAdminService superAdminService)
        {
            _siteManagerService = siteManagerService;
            _superAdminService = superAdminService;
        }

        public async Task<IActionResult> Index()
        {
            var sitemanagers = await _superAdminService.GetSiteManagers();
            return View(sitemanagers);
        }

        //[HttpGet]
        //public async Task<IActionResult> CreateSiteManager()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult CreateSiteManager()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSiteManager(CreateSiteManagerVM model)
        {
            if (ModelState.IsValid)
            {
                await _superAdminService.CreateSiteManager(model);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
