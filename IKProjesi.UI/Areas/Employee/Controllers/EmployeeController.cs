using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Areas.Emloyee.Controllers
{
    [Area("Employee")]

    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}