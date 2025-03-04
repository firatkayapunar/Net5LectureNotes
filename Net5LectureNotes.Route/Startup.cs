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

            // Uygulaman�n routing mekanizmas�n� etkinle�tirir.
            // Rotalar burada hen�z belirlenmez, sadece routing sisteminin kullan�laca��n� belirtir.
            app.UseRouting();

            app.UseAuthorization();

            // Rotalar�n(endpoints) nas�l belirlenece�ini tan�mlar.
            // MapDefaultControllerRoute ile varsay�lan y�nlendirme �ablonu olu�turulur.
            // { controller = Home}/{ action = Index}/{ id ?} deseni, bir HTTP iste�i geldi�inde:
            // - E�er bir controller belirtilmemi�se, Home kullan�l�r.
            // - E�er bir action belirtilmemi�se, Index �al��t�r�l�r.
            // - { id ?} k�sm� iste�e ba�l�d�r, yani belirtilmezse hata vermez.
            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // Gidece�imiz adresi �ekirdek i�erisine gizleyebiliriz. 
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

                // Ya da buradaki tan�mlamalar� kullanmayaca��z ve Attribute Routing ile y�nlendirmeleri yapaca��z. Onun i�in sadece a�a��daki metodu �a��rmal�y�z. Bu metot ile gelen iste�i Controller �zerindeki Route tan�mlamalar� e�le�tir demi� oluyoruz. Genellikle API projelerinde bu tercih ediliyor.
                endpoints.MapControllers();
            });
        }
    }
}
