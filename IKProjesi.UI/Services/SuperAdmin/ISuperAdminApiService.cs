using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using Refit;

namespace IKProjesi.UI.Services.SuperAdmin
{
    public interface ISuperAdminApiService
    {
        [Post("/api/SuperAdmin/CreateSiteManager")]
        Task CreateSiteManagerVM(CreateSiteManagerVM createSiteManager);
    }
}

