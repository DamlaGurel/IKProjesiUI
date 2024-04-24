using IKProjesi.UI.Models.VMs.UserVM;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace IKProjesi.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserVM user)
        {// Api  ye refit kulllanarak login ol token al token değerini ya sesion ya da cookie olarak sakla
            
            return View(user);
        }
    }
}
