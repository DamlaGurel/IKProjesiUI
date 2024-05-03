using IKProjesi.UI.Models.Enums;
using IKProjesi.UI.Models.VMs.UserVM;
using IKProjesi.UI.Services.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Refit;

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
            var tokenString = token.Token;
            await _userService.ValidationToken(tokenString);

            if (string.IsNullOrEmpty(token.Token))
            {
                return RedirectToAction("Login");
            }
            else
            {
                if (token.Role == Job.SuperAdmin.ToString().ToUpper())
                {
                    return RedirectToAction("Index", "SuperAdmin", new { area = "SuperAdmin" });
                }
                else if (token.Role == Job.SiteManager.ToString().ToUpper())
                {
                    return RedirectToAction("Index", "SiteManager", new { area = "SiteManager" });
                }
                else if (token.Role == Job.CompanyManager.ToString().ToUpper())
                {
                    return RedirectToAction("Index", "CompanyManager", new { area = "CompanyManager" });
                }
                else if (token.Role == Job.Employee.ToString().ToUpper())
                {
                    return RedirectToAction("Index", "Employee", new { area = "Employee" });
                }
            }
            return View();

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

        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddMinutes(10)
            };

            Response.Cookies.Append("token", token, cookieOptions);
        }
    }
}
