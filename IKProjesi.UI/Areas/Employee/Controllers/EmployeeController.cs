using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IKProjesi.UI.Models.VMs.PersonelVMs;
using IKProjesi.UI.Services.Company;
using IKProjesi.UI.Services.CompanyManager;
using IKProjesi.UI.Services.SiteManager;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Areas.Emloyee.Controllers
{
    [Area("Employee")]
    public class EmployeeController : Controller
    {
        private readonly ISiteManagerService _siteManagerService;
        private readonly ICompanyManagerService _companyManagerService;
        private readonly ICompanyService _companyService;
        private readonly IEmployeeService _employeeService;

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult CreateTakeOffDay()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTakeOffDay(CreateDaysOffVm model)
        {
            return View();
        }
    }
}