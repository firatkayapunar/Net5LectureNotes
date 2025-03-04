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

            // Taray�c�lar veya istemciler yanl��l�kla http:// adresi �zerinden ba�lanmaya �al���rsa, otomatik olarak https:// adresine y�nlendirilir.
            app.UseHttpsRedirection();

            // Statik dosyalar�(CSS, JavaScript, resimler vb.) sunar.
            // ASP.NET Core varsay�lan olarak wwwroot klas�r�n� kullan�r.
            //  wwwroot / css / style.css
            //  wwwroot / js / site.js
            //  wwwroot / images / logo.png
            // E�er bu middleware eklenmezse, taray�c�lar bu dosyalara do�rudan eri�emez.
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
