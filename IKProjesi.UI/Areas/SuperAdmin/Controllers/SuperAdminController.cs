using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using IKProjesi.UI.Services.SiteManager;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    public class SuperAdminController : Controller
    {
        private readonly ISiteManagerService _siteManagerService;

        public SuperAdminController(ISiteManagerService siteManagerService)
        {
            _siteManagerService = siteManagerService;
        }

        public IActionResult Index()
        {
            return View();
        }

       
        public async Task<IActionResult> AddSiteManager()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSiteManager([FromBody] CreateSiteManagerVM model)
        {
            //await _siteManagerService.CreateSiteManagerVM(model);
            return View();
        }
    }
}
