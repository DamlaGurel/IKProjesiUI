using IKProjesi.UI.Models.VMs.CompanyVMs;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create([FromBody] CreateCompanyVM model)
        {
            return View(model);
        }

    }
}
