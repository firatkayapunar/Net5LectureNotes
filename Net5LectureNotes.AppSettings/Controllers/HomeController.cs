using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Net5LectureNotes.AppSettings.Models;

namespace Net5LectureNotes.AppSettings.Controllers
{
    public class HomeController : Controller
    {
        // Asp .NET Core'daki Yapılandırma Araçları Nelerdir?

        // Appsettings.json | appsettings.{Environment}.json
        // AppSettings.json dosyası, ASP .NET Core uygulamalarının yapılandırma araçlarından birisidr.
        // Yapılandırma, bir uygulamanın herhangi bir ortamda gerçekleştireceği davranışlarını belirlememizi sağlayan statik değerin tanımlanmasıdır.
        // Best practices açısından kodun içerisine username, password, connection string vs. gibi statik tanımlamalar yapılmamılıdır.

        // Secrets.json(Secret Manager Tools) NEDİR?
        // Web uygulamalarında development ortamında kullandığımız bazı verilerimizin canlıya deploy edilmesini istemeyebiliriz.
        // Bu verilerimiz;
        // Veritabanı bilgilerini barındıran connection string bilgisi,
        // Herhangi bir kritik arz eden token değeri,
        // Facebook veya Google gibi third party authentication işlemleri yapmamızı sağlayan client secret id değerler vs. olabilir.
        // Bu veriler developer ortamında kullanılırken, production ortamında kötü niyetli kişilerin uygulama dosyalarına erişim sağladıkları durumlarda elde edemeyecekleri vaziyette bir şekilde ezilmeleri gerekmektedir.
        // İşte bunun için Secret Manager Tool geliştirilmiştir.
        // C:\Users\name\AppData\Roaming\Microsoft\UserSecrets

        // Environment Variables = > Bir web uygulamasında, uygulamanın bulunduğu aşamalara dayalı, davranışı kontrol etmek ve yönlendirmek isteyebiliriz.İşte bunun için Environment dediğimiz değişkenler mevcuttur. Bu değişkenin alabileceği yaygın değerler:
        // Development → Geliştirme ortamı
        // Staging → Test ortamı
        // Production → Canlı ortam

        // IConfiguration => ASP.Net Core IoC provider'ında bulunan bir servistir. Bu servis uygulamadaki appsettings.json dosyasını okumakta ve içerisindeki valueları bize getirmektedir. Dolayısıyla Ioc'den bu servisi herhangi bir controller'da dependency injection ile talep edebilir ve appsettings.json dosyasındaki konfigürasyonları kullanbiliriz.

        IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Options Pattern
        MailInfo _mailInfo;

        public HomeController(IOptions<MailInfo> mailInfo)
        {
            _mailInfo = mailInfo.Value;
        }

        public IActionResult Index()
        {

            var value = _configuration["ExampleText"];
            var value1 = _configuration["Person"]; // Null döner!
            var value2 = _configuration["Person:Name"];
            var value3 = _configuration.GetSection("Person:Name");

            var value4 = value3.Value;

            var mailInfo = _configuration.GetSection("MailInfo").Get<MailInfo>();

            // Options Pattern
            // appsettings.json dosyasındaki konfigürasyonları Dependency Injection ile kullanmamızı sağlayan ve yapılandırılmış olan nesnel modellerle ilgili konfigürasyonları temsil etmemizi sağlayan bir pattern'dır. Startup dosyası içerisinde tanımlamaları yaptık. 
            var value5 = _mailInfo.EmailInfo;
            return View();
        }
    }
}
