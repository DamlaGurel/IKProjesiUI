using IKProjesi.UI.Models.VMs.UserVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IKProjesi.UI.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserApiService _userApiService;

        public UserService(IUserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        public async Task<LoginVM> Login(LoginVM login)
        {
            return await _userApiService.Login(login);
        }

        //public async Task Logout()
        //{
        //}
    }
}
