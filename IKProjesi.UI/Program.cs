using IKProjesi.UI.Services.Company;
using IKProjesi.UI.Services.User;
using IKProjesi.UI.Services.CompanyManager;
using IKProjesi.UI.Services.SiteManager;
using IKProjesi.UI.Services.SuperAdmin;
using IKProjesi.UI.Services.Employee;
using IKProjesi.UI.Extensions.HttpClientHandler;

namespace IKProjesi.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<ICompanyService, CompanyService>()
                            .AddScoped<ISiteManagerService, SiteManagerService>()
                            .AddScoped<ICompanyManagerService, CompanyManagerService>();

            builder.Services.AddTransient<IUserService, UserService>()
                            .AddTransient<ISuperAdminService, SuperAdminService>();
            builder.Services.AddTransient<IEmployeeService, EmployeeService>();

            builder.Services.AddHttpContextAccessor();

            #region localhost
            //builder.Services.AddRefit<IUserApiService, AuthenticatedHttpClientHandler>("http://localhost:44828");
            //builder.Services.AddRefit<ICompanyApiService, AuthenticatedHttpClientHandler>("http://localhost:44828");
            //builder.Services.AddRefit<ICompanyManagerApiService, AuthenticatedHttpClientHandler>("http://localhost:44828");
            //builder.Services.AddRefit<IEmployeeApiService, AuthenticatedHttpClientHandler>("http://localhost:44828");
            //builder.Services.AddRefit<ISiteManagerApiService, AuthenticatedHttpClientHandler>("http://localhost:44828");
            //builder.Services.AddRefit<ISuperAdminApiService, AuthenticatedHttpClientHandler>("http://localhost:44828");
            #endregion

            #region canli
            builder.Services.AddRefit<IUserApiService, AuthenticatedHttpClientHandler>("https://yonetiminsankaynaklari.azurewebsites.net");
            builder.Services.AddRefit<ICompanyApiService, AuthenticatedHttpClientHandler>("https://yonetiminsankaynaklari.azurewebsites.net");
            builder.Services.AddRefit<ICompanyManagerApiService, AuthenticatedHttpClientHandler>("https://yonetiminsankaynaklari.azurewebsites.net");
            builder.Services.AddRefit<IEmployeeApiService, AuthenticatedHttpClientHandler>("https://yonetiminsankaynaklari.azurewebsites.net");
            builder.Services.AddRefit<ISiteManagerApiService, AuthenticatedHttpClientHandler>("https://yonetiminsankaynaklari.azurewebsites.net");
            builder.Services.AddRefit<ISuperAdminApiService, AuthenticatedHttpClientHandler>("https://yonetiminsankaynaklari.azurewebsites.net");
            #endregion

            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            
            app.UseAuthorization();
            app.UseAuthentication();

            app.MapRazorPages();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapAreaControllerRoute(
                name: "siteMngr",
                areaName: "SiteManager",
                pattern: "SiteManager/{controller=SiteManager}/{action=GetSiteManagerSummary}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}");



            app.Run();
        }
    }
}