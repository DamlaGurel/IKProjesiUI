
using IKProjesi.UI.Services.Company;
using IKProjesi.UI.Services.CompanyManager;
using IKProjesi.UI.Services.SiteManager;
using Refit;

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
   .ConfigureHttpClient(client => client.BaseAddress = new Uri("http://localhost:30299"));

            builder.Services.AddRefitClient<ISiteManagerApiService>()
   .ConfigureHttpClient(client => client.BaseAddress = new Uri("http://localhost:5209"));

            builder.Services.AddRefitClient<ICompanyManagerApiService>()
  .ConfigureHttpClient(client => client.BaseAddress = new Uri("http://localhost:6300"));

           


            //builder.Services.AddRefitClient<IAppUserService>().ConfigureHttpClient(c =>
            //{
            //    c.BaseAddress = new Uri("https://localhost:7116/api");
            //});

            builder.Services.AddScoped<ICompanyService, CompanyService>()
                            .AddScoped<ISiteManagerService, SiteManagerService>()
                            .AddScoped<ICompanyManagerService, CompanyManagerService>();



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
                pattern: "{controller=Home}/{action=Index}/{id?}");



            app.Run();
        }
    }
}