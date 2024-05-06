using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using IKProjesi.UI.Models.VMs.UserVM;
using IKProjesi.UI.Services.SiteManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using Refit;

namespace IKProjesi.UI.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserApiService _userApiService;

        public UserService(IUserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        public async Task<TokenVM> Login(LoginVM login)
        {
            var token = await _userApiService.Login(login);
            return token;
        }

        public async Task<string> SendMail(string email)
        {
            var password = await _userApiService.SendMail(email);
            return password;
        }

        //public async Task<TokenVM> GetToken(LoginVM login)
        //{
        //    return await _userApiService.GetToken(login);
        //}

        public async Task Logout()
        {
            await _userApiService.Logout();
        }

        public async Task ChangePassword(ChangePasswordVM password)
        {
            await _userApiService.ChangePassword(password);
        }

        public async Task<string> ValidationToken(string token)
        {
           return await _userApiService.ValidateToken(token);
        }
    }
}
