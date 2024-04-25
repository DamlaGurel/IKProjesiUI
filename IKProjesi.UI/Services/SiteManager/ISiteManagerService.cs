﻿using IKProjesi.UI.Models.VMs.SiteManagerVMs;

namespace IKProjesi.UI.Services.SiteManager
{
    public interface ISiteManagerService
    {
        Task<SiteManagerSummaryVM> GetSiteManagerSummary(int id);
        Task<SiteManagerDetailsVM> SiteManagerDetails(int id);
        Task GetSiteManagerUpdate(SiteManagerUpdateVM siteManagerUpdateVM);
        Task CreateSiteManager(CreateSiteManagerVM createSiteManager);
    }
}
