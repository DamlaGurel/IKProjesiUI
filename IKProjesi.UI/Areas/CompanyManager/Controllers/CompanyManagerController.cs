using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.PersonelVMs;
using IKProjesi.UI.Services.Personel;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Areas.CompanyManager.Controllers
{
    public class CompanyManagerController : Controller
    {
        private readonly IPersonelApiService _personelApiService;

        public CompanyManagerController(IPersonelApiService personelApiService)
        {
            _personelApiService = personelApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreatePersonel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonel(CreatePersonelVM model)
        {
            await _personelApiService.CreatePersonel(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
