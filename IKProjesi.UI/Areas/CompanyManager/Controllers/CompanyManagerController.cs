﻿using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Services.CompanyManager;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Areas.CompanyManager.Controllers
{
    [Area("CompanyManager")]
    public class CompanyManagerController : Controller
    {
        private readonly ICompanyManagerService _companyManagerService;

        public CompanyManagerController(ICompanyManagerService companyManagerService)
        {
            _companyManagerService = companyManagerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyManagerSummary(int id = 10)
        {
            var companyManagerSummary = await _companyManagerService.GetCompanyManagerSummary(id);
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyManagerDetail(int id = 10)
        {
            var companyManagerDetail = await _companyManagerService.GetCompanyManagerDetails(id);
            return View(companyManagerDetail);
        }


        [HttpGet]
        public IActionResult GetCompanyManagerUpdate(int id = 10)
        {
            var companyManagerUpdate = new UpdateCompanyManagerVm { Id = id };
            return View(companyManagerUpdate);
        }


        [HttpPost]
        public async Task<IActionResult> GetCompanyManagerUpdate(UpdateCompanyManagerVm companyManagerUpdateVM)
        {
            companyManagerUpdateVM.Id = 5;
            await _companyManagerService.GetCompanyManagerUpdate(companyManagerUpdateVM);
            return RedirectToAction("GetCompanyManagerDetail");
        }


    }
}