using IKProjesi.UI.Models.VMs.UserVM;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace IKProjesi.UI.Services.User
{
    public interface IUserApiService
    {
        [Post("/api/User/Login")]
        Task<TokenVM> Login(LoginVM user);

        //[Get("/api/User/Token")]
        //Task<string> GetUser([Header("Authorization")] string bearerToken);
    }
}
