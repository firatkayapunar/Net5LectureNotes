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
                // Area Route Tan�m�
                // exists => Route'un bir Area ile e�le�mesi i�in k�s�tkama uygular.
                endpoints.MapControllerRoute(
                    name: "areaDefault",
                    pattern: "{area: exists}/{controller=Home}/{action=Index}/{id?}"
                   );

                // MapAreaControllerRoute ise bir area'ya ait �zel rota belirlememizi sa�lar. B�ylece art� �zel bir route belirlemi� oluruz.
                endpoints.MapAreaControllerRoute(
                    name: "areaDefault1",
                    areaName: "AdministrationPanel",
                    pattern: "administration/{controller=Home}/{action=Index}/{id?}"
                    );

                // Default Route Tan�m�
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
