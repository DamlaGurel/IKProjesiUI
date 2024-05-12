using IKProjesi.UI.Models.Enums;
using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using IKProjesi.UI.Services.SiteManager;
using IKProjesi.UI.Services.SuperAdmin;
using IKProjesi.UI.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    public class SuperAdminController : Controller
    {
        private readonly ISiteManagerService _siteManagerService;
        private readonly ISuperAdminService _superAdminService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserService _userService;

        public SuperAdminController(ISiteManagerService siteManagerService, ISuperAdminService superAdminService, IHttpContextAccessor contextAccessor, IUserService userService)
        {
            _siteManagerService = siteManagerService;
            _superAdminService = superAdminService;
            _contextAccessor = contextAccessor;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["UserId"] = HttpContext.Session.GetInt32("UserId");
            var sitemanagers = await _superAdminService.GetSiteManagers();
            return View(sitemanagers);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSiteManager()
        {
            ViewBag.Department = Enum.GetValues<Department>();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateSiteManager(CreateSiteManagerVM model)
        {
            ViewBag.Department = Enum.GetValues<Department>();
            if (ModelState.IsValid)
            {
                await _superAdminService.CreateSiteManager(model);
                TempData["Success"] = "Site Yöneticisi Eklendi.";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
