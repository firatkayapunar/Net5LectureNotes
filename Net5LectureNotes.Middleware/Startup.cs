using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Net5LectureNotes.Middleware
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

            // Tarayýcýlar veya istemciler yanlýþlýkla http:// adresi üzerinden baðlanmaya çalýþýrsa, otomatik olarak https:// adresine yönlendirilir.
            app.UseHttpsRedirection();

            // Statik dosyalarý(CSS, JavaScript, resimler vb.) sunar.
            // ASP.NET Core varsayýlan olarak wwwroot klasörünü kullanýr.
            //  wwwroot / css / style.css
            //  wwwroot / js / site.js
            //  wwwroot / images / logo.png
            // Eðer bu middleware eklenmezse, tarayýcýlar bu dosyalara doðrudan eriþemez.
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
