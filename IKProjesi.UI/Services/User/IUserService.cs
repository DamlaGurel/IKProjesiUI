using IKProjesi.UI.Models.VMs.UserVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace IKProjesi.UI.Services.User
{
    public interface IUserService 
    {
        Task<LoginVM> Login(LoginVM login);
        //Task Logout();
    }
}
