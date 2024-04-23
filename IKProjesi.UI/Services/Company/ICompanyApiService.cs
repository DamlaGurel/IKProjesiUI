﻿using IKProjesi.UI.Models.VMs.CompanyVMs;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace IKProjesi.UI.Services.Company
{
    public interface ICompanyApiService
    {
        [Get("/api/Company/Index")]
        Task<List<CompanyListVM>> GetCompanies();

        [Get("api/SiteManager/Create")]
        Task<IActionResult> Create();

        [Post("api/SiteManager/Create")]
        Task<IActionResult> Create([FromBody] CreateCompanyVM model);
    }
}
