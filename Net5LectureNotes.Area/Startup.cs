using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Net5LectureNotes.Area
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Area Route Tanýmý
                // exists => Route'un bir Area ile eþleþmesi için kýsýtkama uygular.
                endpoints.MapControllerRoute(
                    name: "areaDefault",
                    pattern: "{area: exists}/{controller=Home}/{action=Index}/{id?}"
                   );

                // MapAreaControllerRoute ise bir area'ya ait özel rota belirlememizi saðlar. Böylece artý özel bir route belirlemiþ oluruz.
                endpoints.MapAreaControllerRoute(
                    name: "areaDefault1",
                    areaName: "AdministrationPanel",
                    pattern: "administration/{controller=Home}/{action=Index}/{id?}"
                    );

                // Default Route Tanýmý
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
