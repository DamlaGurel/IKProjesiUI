using IKProjesi.UI.Models.VMs.UserVM;
using IKProjesi.UI.Services.User;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace IKProjesi.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginVM user)
        {// Api  ye refit kulllanarak login ol token al token değerini ya sesion ya da cookie olarak sakla
            
            return View(user);
        }

        //[HttpPost]
        //public async Task<IActionResult> Logout() 
        //{
        //    //await _userService.Logout();
        //    TempData["Success"] = "Kullanıcı Çıkışı Gerçekleştirildi.";

        //    return RedirectToAction("Index", "Home");
        //}
    }
}
