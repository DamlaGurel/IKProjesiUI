﻿using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using IKProjesi.UI.Services.SiteManager;

namespace IKProjesi.UI.Services.SuperAdmin
{
    public class SuperAdminService : ISuperAdminService
    {
        private readonly ISuperAdminApiService _superAdminApiService;

        public SuperAdminService(ISuperAdminApiService superAdminApiService)
        {
            _superAdminApiService = superAdminApiService;
        }

        public async Task CreateSiteManager(CreateSiteManagerVM createSiteManager)
        {
            await _superAdminApiService.CreateSiteManagerVM(createSiteManager);
        }
    }
}
