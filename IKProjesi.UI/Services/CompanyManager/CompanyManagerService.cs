﻿using System;
using System.Reflection;
using IKProjesi.UI.Models.VMs.CompanyManagerVMs;
using IKProjesi.UI.Models.VMs.CompanyVMs;
using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using IKProjesi.UI.Services.Company;
using IKProjesi.UI.Services.SiteManager;
using Microsoft.AspNetCore.Mvc;
using Refit;


namespace IKProjesi.UI.Services.CompanyManager
{
    public class CompanyManagerService : ICompanyManagerService
    {
        private readonly ICompanyManagerApiService _companyManagerApiService;

        public CompanyManagerService(ICompanyManagerApiService companyManagerApiService)
        {
            _companyManagerApiService = companyManagerApiService;
        }

        public async Task CreateCompanyManager(CreateCompanyManagerVM model)
        {
            if (model.Image is not null)
                model.ImageString = await SaveImage(model.Image);

            await _companyManagerApiService.CreateCompanyManager(model);
        }

        private async Task<string> SaveImage(IFormFile image)
        {
            var imageFile = image;
            byte[] imageBytes = null;

            using (var memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);

                if (memoryStream.Length < 2097152)
                    imageBytes = memoryStream.ToArray();
                else
                    imageBytes = null;
            }

            string imageString = Convert.ToBase64String(imageBytes);
            return imageString;
        }

        public async Task<List<ListCompanyManagerVM>> GetCompanyManagers()
        {
            return await _companyManagerApiService.GetCompanyManagers();
        }

        public async Task<SummaryCompanyManagerVM> GetCompanyManagerSummary(int id)
        {
            return await _companyManagerApiService.GetCompanyManagerSummary(id);
        }

        public async Task GetCompanyManagerUpdate(UpdateCompanyManagerVM updateCompanyManager)
        {
            await _companyManagerApiService.GetCompanyManagerUpdate(updateCompanyManager);
        }

        public async Task<DetailsCompanyManagerVM> GetCompanyManagerDetails(int id)
        {
            return await _companyManagerApiService.GetCompanyManagerDetails(id);
        }

    }
}

