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

        // ConfigureServices, bu uygulamada kullan�lacak servislerin eklendi�i/konfigure edildi�i metottur.
        // Servis Ne Demek ?
        // Belirli i�lere odaklanm�� ve o i�in sorumlulu�unu �stlenmi� k�t�phaneler/s�n�flard�r.

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // ASP.NET Core uygulamam�zda ConfigureServices metoduna yukar�daki sat�r� ekledi�imizde �u i�lemler ger�ekle�mi� olur:

            // MVC Mimarisi Aktif Hale Gelir:
            // Uygulaman�z�n Model-View - Controller(MVC) yap�s�n� kullanmas�n� sa�lar.
            // Controller ve View deste�i eklenmi� olur.

            // Routing(Y�nlendirme) Sistemi Tan�mlan�r:
            // Uygulaman�zda Controller tabanl� bir y�nlendirme mekanizmas�(Routing) aktif olur.
            // �rne�in, / home / index gibi URL�ler ilgili Controller�a y�nlendirilir.

            // Controller�lar Kullan�labilir Hale Gelir:
            // Controllers klas�r�ne eklenen HomeController, ProductController gibi s�n�flar, art�k HTTP isteklerine cevap verebilir.

            // Razor Engine Kullan�labilir:
            // Razor Engine kullanarak .cshtml dosyalar� ile sayfa olu�turabiliriz.
            // Views klas�r�ne eklenen.cshtml sayfalar�, kullan�c�ya g�sterilebilir.

            // Model Binding ve Validation Mekanizmas� �al���r:
            // HTTP isteklerinden gelen veriler Model�lere ba�lanabilir(Model Binding).
            // Form do�rulama i�lemleri gibi i�lemler de devreye girer.

            // Dependency Injection Entegrasyonu Sa�lan�r:
            // Controller'lar i�inde constructor injection y�ntemi ile servisleri (DbContext, ILogger, IRepository) kullanabiliriz.

            // **************

            // Alternatifler:

            // Sadece API geli�tirmek istersek:
            // services.AddControllers();
            // Bu durumda View deste�i olmaz, sadece API Controller�lar�([ApiController] ile i�aretlenmi� olanlar) �al���r.

            // Razor Pages ile geli�tirme yapmak istersek:
            // services.AddRazorPages();
            // MVC kullanmadan Razor Pages tabanl� bir yap� ile �al���rs�n�z.
        }

        // Bu metotta da uygulamada kullan�lacak middleware katmanlar�n� �a��rmaktay�z.
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

            // Endpoint: Yap�lan iste�in var�� noktas�.
            // Bu uygulamaya gelen isteklerin hangi rotalar/�ablonlar e�li�inde gelebilece�ini buradan bildirece�iz.
            app.UseEndpoints(endpoints =>
            {
                // {controller=Home}/{action=Index}/{id?} => Bu uygulamaya yap�lacak olan istekler bu �emaya uygun bir �ekilde yap�lacakt�r.
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
