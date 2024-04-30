using IKProjesi.UI.Models.VMs.UserVM;
using Microsoft.AspNetCore.Mvc;
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

        //[Get("/api/User/Token")]
        //Task<string> GetUser([Header("Authorization")] string bearerToken);
    }
}
