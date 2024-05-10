using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using IKProjesi.UI.Models.VMs.UserVM;
using Refit;

namespace IKProjesi.UI.Services.User
{
    public interface IUserApiService
    {
        [Post("/api/User/Login")]
        Task<TokenVM> Login(LoginVM user);

        [Post("/api/Mail/SendMail/{email}")]
        Task<string> SendMail(string email);

        [Get("/api/User/Logout")]
        Task Logout();

        [Post("/api/User/ChangePassword")]
        Task ChangePassword(ChangePasswordVM password);

        [Get("/api/SuperAdmin/SiteManagerDetail")]
        Task<List<SiteManagerDetailsVM>> SiteManagerDetails();

        [Post("/api/User/ValidateCredentials/{email}/{password}")]
        Task<bool> ValidateCredentials(string email, string password);
    }
}
