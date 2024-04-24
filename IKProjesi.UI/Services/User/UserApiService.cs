using IKProjesi.UI.Models.VMs.UserVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace IKProjesi.UI.Services.User
{
    public class UserApiService : IUserApiService
    {
        private readonly IUserApiService _userApiService;
        public UserApiService(IUserApiService userApiService)
        {
            _userApiService = userApiService;
        }
        public async Task Login(UserVM user)
        {
            await _userApiService.Login(user);
        }
    }
}
