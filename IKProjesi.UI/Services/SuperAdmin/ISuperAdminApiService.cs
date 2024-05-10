using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using Refit;
using System.Net;

namespace IKProjesi.UI.Services.SuperAdmin
{
    public interface ISuperAdminApiService
    {
        [Post("/api/SuperAdmin/CreateSiteManager")]
        Task CreateSiteManagerVM(CreateSiteManagerVM createSiteManager);

        [Get("/api/SuperAdmin/SiteManagerDetail")]
        Task<List<SiteManagerDetailsVM>> SiteManagerDetails();
    }
}

