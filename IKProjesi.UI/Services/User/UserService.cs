using IKProjesi.UI.Models.VMs.UserVM;
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

        //public async Task<TokenVM> GetToken(LoginVM login)
        //{
        //    return await _userApiService.GetToken(login);
        //}


        //public async Task Logout()
        //{
        //}
    }
}
