using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Areas.SiteManager.Controllers
{
    public class SiteManagersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}