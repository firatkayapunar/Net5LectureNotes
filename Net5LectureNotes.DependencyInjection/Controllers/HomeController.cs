using Microsoft.AspNetCore.Mvc;

namespace Net5LectureNotes.DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        // DIP sınıfların  birbirleriyle doğrudan bağımlı olmaması gerektiğini, her ikisinin de soyutlamalara bağlı olması gerektiğini savunan prensiptir.

        // IoC, uygulamanın kontrol akışını dış bir sisteme devrederek, nesne yönetimini otomatik hale getirir.Uygulamamızda nesneleri oluşturmak, bu nesnelerin ihtiyaç duyduğu bağımlılıkları sağlamak, yaşam döngülerini yönetmek gibi işlemleri biz (geliştirici) elle yaparız. Örneğin, bir sınıfın içinde başka bir sınıfı new operatörüyle oluşturabiliriz. IOC prensibi sayesinde, bu kontrol işlerini bizim yerimize IOC konteyneri (örneğin ASP.NET Core'un yerleşik DI konteyneri) üstlenir. Yani, hangi nesnenin ne zaman oluşturulacağı, hangi bağımlılıkların verileceği, nesnenin ne zaman yok edileceği gibi sorumluluklar dışarıdaki sisteme aktarılır.

        // DI, Inversion of Control'u kullanarak, bağımlılıkların dışarıdan enjekte edilmesini sağlayan yöntemdir yani DI kullanarak enjekte edilecek olan tüm nesneler IOC Container dediğimiz bir sınıfta tutulur ve DIP'in gerektirdiği yapılandırmayı kolaylaştırır.

        // Sonuç olarak, DIP nesnelerin birbirine doğrudan bağımlı olmaması gerektiğini savunurken, DI bu prensibi uygulamak için bir yöntem sunar. DI, bağımlılıkları dışarıdan enjekte ederken, bu süreci yönetmek için IOC prensibinden yararlanır.

        // ASP .NET Core uygulamalarında IoC yapılanmasını sağlayan third party frameworkler mevcuttur.
        // Structuremap
        // AutoFac
        // Ninject
        // Asp.Net Core mimarisi, bu third party kütüphaneler kadar yetenekli olmasada içerisinde built-in (dahili) olarak IoC modülü barındırmaktadır.
        // Built-in IOC, içerisinde koyulacak nesneleri üç farklı davranışla alabilmektedir.

        // Singleton
        // Uygulama bazlı tekil nesne oluşturur. Tüm taleplere o nesneyi gönderir.

        // Scoped
        // Her request (HTTP isteği) başına bir nesne üretir ve o request pipeline'nında olan tüm isteklere o nesneyi gönderir.

        // Transient
        // Her request'in (HTTP isteği) her talebine karşılık bir nesne üretir ve gönderir.
        public IActionResult Index()
        {
            return View();
        }
    }
}
