using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IKProjesi.UI.Services.SiteManager;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Areas.SiteManager.Controllers
{
    [Area("SiteManager")]
    public class SiteManagerController : Controller
    {
        private readonly ISiteManagerService _siteManagerService;

        public SiteManagerController(ISiteManagerService siteManagerService)
        {
            _siteManagerService = siteManagerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetSiteManagerSummary(int id = 1)
        {
            var siteManagerSummary = await _siteManagerService.GetSiteManagerSummary(id);
            return View(siteManagerSummary);
        }

    }
}