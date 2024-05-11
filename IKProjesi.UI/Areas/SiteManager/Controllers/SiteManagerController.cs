using IKProjesi.UI.Extensions;
using IKProjesi.UI.Models.Enums;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.CompanyVMs;
using IKProjesi.UI.Models.VMs.Pagination;
using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using IKProjesi.UI.Models.VMs.UserVM;
using IKProjesi.UI.Services.Company;
using IKProjesi.UI.Services.CompanyManager;
using IKProjesi.UI.Services.SiteManager;
using IKProjesi.UI.Services.User;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace IKProjesi.UI.Areas.SiteManager.Controllers
{
    [Area("SiteManager")]
    public class SiteManagerController : Controller
    {
        private readonly ISiteManagerService _siteManagerService;
        private readonly ICompanyManagerService _companyManagerService;
        private readonly ICompanyService _companyService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserService _userService;

        public SiteManagerController(ISiteManagerService siteManagerService, ICompanyManagerService companyManagerService, ICompanyService companyService, IHttpContextAccessor contextAccessor, IUserService userService)
        {
            _siteManagerService = siteManagerService;
            _companyManagerService = companyManagerService;
            _companyService = companyService;
            _contextAccessor = contextAccessor;
            _userService = userService;
        }


        public async Task<IActionResult> IndexAsync()
        {
            
            var role = Job.SITEMANAGER.ToString().ToUpper();
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
            int Id = HttpContext.Session.GetInt32("UserId") ?? 0;
            var siteManagerSummary = await _siteManagerService.GetSiteManagerSummary(Id);
            return View(siteManagerSummary);

        }

        [HttpGet]
        public async Task<IActionResult> GetSiteManagerDetail(int id)
        {
            int Id = HttpContext.Session.GetInt32("UserId") ?? 0;
            var siteManagerDetail = await _siteManagerService.SiteManagerDetails(Id);
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
            var siteManager = await _siteManagerService.GetSiteManagerUpdate(siteManagerUpdateVM);
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
            model.CreateCompanyManagerVM.CompanyId = companyId;

            var vm = model.CreateCompanyManagerVM;
            await _companyManagerService.CreateCompanyManager(vm);

            return RedirectToAction(nameof(CompanyManagerList));
        }

        [HttpGet]
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