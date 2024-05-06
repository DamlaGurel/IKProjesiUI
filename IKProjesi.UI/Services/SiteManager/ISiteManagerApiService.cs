using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using Refit;

namespace IKProjesi.UI.Services.SiteManager
{
    //[Headers("Authorization: Bearer")]
    public interface ISiteManagerApiService
    {
        [Get("/api/SiteManager/SiteManagerSummary/{id}")]
        Task<SiteManagerSummaryVM> GetSiteManagerSummary(int id);

        [Get("/api/SiteManager/SiteManagerDetails/{id}")]
        Task<SiteManagerDetailsVM> GetSiteManagerDetails(int id);

        [Put("/api/SiteManager/UpdateSiteManager")]
        Task GetSiteManagerUpdate(SiteManagerUpdateVM siteManagerUpdateVM);
    }
}
