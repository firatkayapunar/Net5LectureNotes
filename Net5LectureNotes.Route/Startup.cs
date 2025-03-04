using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Net5LectureNotes.Route
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

            // Uygulamanýn routing mekanizmasýný etkinleþtirir.
            // Rotalar burada henüz belirlenmez, sadece routing sisteminin kullanýlacaðýný belirtir.
            app.UseRouting();

            app.UseAuthorization();

            // Rotalarýn(endpoints) nasýl belirleneceðini tanýmlar.
            // MapDefaultControllerRoute ile varsayýlan yönlendirme þablonu oluþturulur.
            // { controller = Home}/{ action = Index}/{ id ?} deseni, bir HTTP isteði geldiðinde:
            // - Eðer bir controller belirtilmemiþse, Home kullanýlýr.
            // - Eðer bir action belirtilmemiþse, Index çalýþtýrýlýr.
            // - { id ?} kýsmý isteðe baðlýdýr, yani belirtilmezse hata vermez.
            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // Gideceðimiz adresi çekirdek içerisine gizleyebiliriz. 
                endpoints.MapControllerRoute(
                    "default2",
                    "House",
                    new { controller = "Home", action = "Index" });

                // Route Constraints
                endpoints.MapControllerRoute(
                     name: "default3",
                     pattern: "{controller=Home}/{action=Index}/{id:int?}");

                endpoints.MapControllerRoute(
                    name: "default4",
                    pattern: "{controller=Home}/{action=Index}/{name:length(12)}");

                // Ya da buradaki tanýmlamalarý kullanmayacaðýz ve Attribute Routing ile yönlendirmeleri yapacaðýz. Onun için sadece aþaðýdaki metodu çaðýrmalýyýz. Bu metot ile gelen isteði Controller üzerindeki Route tanýmlamalarý eþleþtir demiþ oluyoruz. Genellikle API projelerinde bu tercih ediliyor.
                endpoints.MapControllers();
            });
        }
    }
}
