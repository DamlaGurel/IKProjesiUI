
using IKProjesi.UI.Services.Company;
using IKProjesi.UI.Services.User;
using NuGet.Common;
using IKProjesi.UI.Services.CompanyManager;
using IKProjesi.UI.Services.SiteManager;
using Refit;
using IKProjesi.UI.Services.SuperAdmin;

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


            builder.Services.AddRefitClient<ICompanyApiService>()
                            .ConfigureHttpClient(client => client.BaseAddress = new Uri("http://localhost:19876"));

            builder.Services.AddRefitClient<IUserApiService>()
                            .ConfigureHttpClient(client => client.BaseAddress = new Uri("http://localhost:19876"));

            builder.Services.AddRefitClient<ISiteManagerApiService>()
                            .ConfigureHttpClient(client => client.BaseAddress = new Uri("http://localhost:19876"));

            builder.Services.AddRefitClient<ICompanyManagerApiService>()
                            .ConfigureHttpClient(client => client.BaseAddress = new Uri("http://localhost:19876"));

            builder.Services.AddRefitClient<ISuperAdminApiService>()
                            .ConfigureHttpClient(client => client.BaseAddress = new Uri("http://localhost:19876"));

            builder.Services.AddScoped<ICompanyService, CompanyService>()
                            .AddScoped<ISiteManagerService, SiteManagerService>()
                            .AddScoped<ICompanyManagerService, CompanyManagerService>();


            builder.Services.AddTransient<IUserService, UserService>()
                            .AddTransient<ISuperAdminService, SuperAdminService>();

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

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