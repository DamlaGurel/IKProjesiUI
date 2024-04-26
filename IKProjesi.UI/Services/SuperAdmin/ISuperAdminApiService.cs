using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using Refit;

namespace IKProjesi.UI.Services.SuperAdmin
{
    public interface ISuperAdminApiService
    {
        [Post("/api/SiteManager/CreateSiteManager")]
        Task<CreateSiteManagerVM> CreateSiteManagerVM(CreateSiteManagerVM createSiteManager);
    }
}

