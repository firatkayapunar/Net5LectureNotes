using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Net5LectureNotes.FirstStep
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // ConfigureServices, bu uygulamada kullanýlacak servislerin eklendiði/konfigure edildiði metottur.
        // Servis Ne Demek ?
        // Belirli iþlere odaklanmýþ ve o iþin sorumluluðunu üstlenmiþ kütüphaneler/sýnýflardýr.

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // ASP.NET Core uygulamamýzda ConfigureServices metoduna yukarýdaki satýrý eklediðimizde þu iþlemler gerçekleþmiþ olur:

            // MVC Mimarisi Aktif Hale Gelir:
            // Uygulamanýzýn Model-View - Controller(MVC) yapýsýný kullanmasýný saðlar.
            // Controller ve View desteði eklenmiþ olur.

            // Routing(Yönlendirme) Sistemi Tanýmlanýr:
            // Uygulamanýzda Controller tabanlý bir yönlendirme mekanizmasý(Routing) aktif olur.
            // Örneðin, / home / index gibi URL’ler ilgili Controller’a yönlendirilir.

            // Controller’lar Kullanýlabilir Hale Gelir:
            // Controllers klasörüne eklenen HomeController, ProductController gibi sýnýflar, artýk HTTP isteklerine cevap verebilir.

            // Razor Engine Kullanýlabilir:
            // Razor Engine kullanarak .cshtml dosyalarý ile sayfa oluþturabiliriz.
            // Views klasörüne eklenen.cshtml sayfalarý, kullanýcýya gösterilebilir.

            // Model Binding ve Validation Mekanizmasý Çalýþýr:
            // HTTP isteklerinden gelen veriler Model’lere baðlanabilir(Model Binding).
            // Form doðrulama iþlemleri gibi iþlemler de devreye girer.

            // Dependency Injection Entegrasyonu Saðlanýr:
            // Controller'lar içinde constructor injection yöntemi ile servisleri (DbContext, ILogger, IRepository) kullanabiliriz.

            // **************

            // Alternatifler:

            // Sadece API geliþtirmek istersek:
            // services.AddControllers();
            // Bu durumda View desteði olmaz, sadece API Controller’larý([ApiController] ile iþaretlenmiþ olanlar) çalýþýr.

            // Razor Pages ile geliþtirme yapmak istersek:
            // services.AddRazorPages();
            // MVC kullanmadan Razor Pages tabanlý bir yapý ile çalýþýrsýnýz.
        }

        // Bu metotta da uygulamada kullanýlacak middleware katmanlarýný çaðýrmaktayýz.
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

            // Endpoint: Yapýlan isteðin varýþ noktasý.
            // Bu uygulamaya gelen isteklerin hangi rotalar/þablonlar eþliðinde gelebileceðini buradan bildireceðiz.
            app.UseEndpoints(endpoints =>
            {
                // {controller=Home}/{action=Index}/{id?} => Bu uygulamaya yapýlacak olan istekler bu þemaya uygun bir þekilde yapýlacaktýr.
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
