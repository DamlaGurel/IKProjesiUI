using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Areas.SiteManager.Controllers
{
    public class SiteManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CompanyManagerList()
        {
            return View();
        }
        public IActionResult AddCompanyManager()
        {
            return View();
        }

    }
}