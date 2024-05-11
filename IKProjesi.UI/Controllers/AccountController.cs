using IKProjesi.UI.Extensions;
using IKProjesi.UI.Models.Enums;
using IKProjesi.UI.Models.VMs.UserVM;
using IKProjesi.UI.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;

        public AccountController(IUserService userService, IHttpContextAccessor contextAccessor)
        {
            _userService = userService;
            _contextAccessor = contextAccessor;
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
        public async Task<IActionResult> ValidationCredentials(string email, string password)
        {
            var user = await _userService.ValidateCredentials(email, password);
            if (user)
            {
                return await Login(new LoginVM { Email = email, Password = password });
            }
            else
            {
                TempData["Warning"] = "Kullanıcı adı ya da şifre hatalı";
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM user)
        {
            if (ModelState.IsValid)
            {
                var token = await _userService.Login(user);
                _contextAccessor.HttpContext.Session.AddObjectSession(token);
                _contextAccessor.HttpContext.Session.SetInt32("UserId", Convert.ToInt32(token.UserId));
                _contextAccessor.HttpContext.Session.SetString("FirstName", token.FirstName);
                //ViewData["FirstName"] = token.FirstName;
                ViewBag.FirstName = token.FirstName;

                if (string.IsNullOrEmpty(token.Token))
                {
                    TempData["Warning"] = "Kullanıcı adı ya da şifre hatalı.";
                    return RedirectToAction("Login");
                }
                else
                {
                    if (token.Role == Job.SUPERADMIN.ToString().ToUpper())
                    {
                        return RedirectToAction("Index", "SuperAdmin", new { area = "SuperAdmin" });
                    }
                    else if (token.Role == Job.SITEMANAGER.ToString().ToUpper())
                    {
                        return RedirectToAction("Index", "SiteManager", new { area = "SiteManager" });
                    }
                    else if (token.Role == Job.COMPANYMANAGER.ToString().ToUpper())
                    {
                        return RedirectToAction("GetCompanyManagerSummary", "CompanyManager", new { area = "CompanyManager" });
                    }
                    else if (token.Role == Job.EMPLOYEE.ToString().ToUpper())
                    {
                        return RedirectToAction("GetEmployeeSummary", "Employee", new { area = "Employee" });
                    }
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

            if (string.IsNullOrEmpty(email))
            {
                TempData["Warning"] = "Lütfen e-posta adresinizi giriniz.";
            }
            if (ModelState.IsValid)
            {
                var password = await _userService.SendMail(email);
                if (string.IsNullOrEmpty(password))
                {
                    TempData["Warning"] = "Geçiçi şifreniz gönderilemedi. Lütfen kayıtlı bir mail adresi giriniz.";
                    return View();
                }
                TempData["Success"] = "Şifreniz gönderildi. Lütfen mailinizi kontrol ediniz.";
                return RedirectToAction("ChangePassword", "Account");
            }
            return View();
        }

        //[HttpGet]
        //public IActionResult SendPassword()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task SendPassword(string personalEmail)
        {
            if (string.IsNullOrEmpty(personalEmail))
            {
                TempData["Warning"] = "Lütfen e-posta adresinizi giriniz.";
            }
            if (ModelState.IsValid)
            {
                var infomation = await _userService.SendPassword(personalEmail);
                if (string.IsNullOrEmpty(infomation))
                {
                    //return View();
                }
                TempData["Success"] = "Bilgileriniz gönderildi. Lütfen mailinizi kontrol ediniz.";
                //return RedirectToAction("Login", "Account");
            }
            //return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM password)
        {
            if (ModelState.IsValid)
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
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            TempData["Success"] = "Çıkış yapıldı.";
            return RedirectToAction("Login", "Account");
        }

        
    }
}
