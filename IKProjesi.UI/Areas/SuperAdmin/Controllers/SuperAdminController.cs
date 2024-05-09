using IKProjesi.UI.Models.Enums;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using IKProjesi.UI.Services.SiteManager;
using IKProjesi.UI.Services.SuperAdmin;
using IKProjesi.UI.Services.User;
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
            var token = _contextAccessor.HttpContext.Request.Cookies["token"];
            var role = _contextAccessor.HttpContext.Request.Cookies["role"];
            await _userService.ValidationToken(token, role);
            var sitemanagers = await _superAdminService.GetSiteManagers();
            return View(sitemanagers);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSiteManager()
        {
            var token = _contextAccessor.HttpContext.Request.Cookies["token"];
            var role = _contextAccessor.HttpContext.Request.Cookies["role"];
            await _userService.ValidationToken(token, role);
            ViewBag.Department = Enum.GetValues<Department>();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateSiteManager(CreateSiteManagerVM model)
        {
            var token = _contextAccessor.HttpContext.Request.Cookies["token"];
            var role = _contextAccessor.HttpContext.Request.Cookies["role"];
            await _userService.ValidationToken(token, role);
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
