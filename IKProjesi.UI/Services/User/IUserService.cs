using IKProjesi.UI.Models.VMs.SiteManagerVMs;
using IKProjesi.UI.Models.VMs.UserVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;
using System.Reflection;
using System.Text;

namespace IKProjesi.UI.Services.User
{
    public interface IUserService 
    {
        Task<TokenVM> Login(LoginVM login);
        Task<string> SendMail(string email);
        Task ChangePassword(ChangePasswordVM password);
        Task Logout();
        Task<string> ValidationToken(string token);
    }
}
