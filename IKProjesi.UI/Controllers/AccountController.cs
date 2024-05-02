using IKProjesi.UI.Models.Enums;
using IKProjesi.UI.Models.VMs.UserVM;
using IKProjesi.UI.Services.User;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Login(LoginVM user)
        {
            
            var token = await _userService.Login(user);

            if (string.IsNullOrEmpty(token.Token))
            {
                return RedirectToAction("Login");
            }
            else
            {
                var userToken = await _userService.Login(user);

                if (userToken != null)
                {
                    if (userToken.Role == Job.SuperAdmin.ToString().ToUpper())
                    {
                        return RedirectToAction("Index", "SuperAdmin", new { area = "SuperAdmin" });
                    }
                    else if (userToken.Role == Job.SiteManager.ToString().ToUpper())
                    {
                        return RedirectToAction("Index", "SiteManager", new { area = "SiteManager" });
                    }
                    else if (userToken.Role == Job.CompanyManager.ToString().ToUpper())
                    {
                        return RedirectToAction("Index", "CompanyManager", new { area = "CompanyManager" });
                    }

                    return RedirectToAction("Index", "Employee", new { area = "Employee" });

                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
        }
        public IActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMail(string email)
        {
            var password = await _userService.SendMail(email);
            if (password == null) 
            {
                TempData["Warning"] = "Geçiçi şifreniz gönderilemedi. Tekrar deneyiniz";
                return View();
            }
            TempData["Success"] = "Şifreniz gönderildi. Lütfen mailinizi kontrol ediniz.";
            return RedirectToAction("ChangePassword", "Account");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        { 
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM password)
        {
           await _userService.ChangePassword(password);
            if (password == null) 
            {
                TempData["Warning"] = "Şifreniz değiştirilemedi";
                return View();
            }
            TempData["Success"] = "Şifreniz değiştirildi.";
            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            TempData["Success"] = "Çıkış yapıldı.";
            return RedirectToAction("Login", "Account");
        }
    }
}
