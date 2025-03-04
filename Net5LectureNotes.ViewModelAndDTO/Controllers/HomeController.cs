using Microsoft.AspNetCore.Mvc;

namespace Net5LectureNotes.ViewModelAndDTO.Controllers
{
    public class HomeController : Controller
    {
        // ViewModel Nedir?
        // ViewModel, temelde iki farklı senaryoya karşılık sorumluluk üstlenen ve biz yazılım geliştiricilerin işini kolaylaştıran operasyonel nesnelerdir.

        // 1. Senaryo
        // OOP yapılanmasında bir modelin kullanıcıyla etkileşimi neticesinde kullanılan ve esas datanın memberlarını temsil eden ve süreçte ilgili model yerine veri taşıma/transfer operasyonunu üstlenen bir nesnedir.

        // 2. Senaryo
        // Birden fazla modeli/değeri/veriyi tek bir nesne üzerinde birleştirme görevi gören nesnedir.

        // DTO(Data Transfer Object) Nedir?
        // Herhangi bir davranışı olmayan ve uygulamanın çeşitli yerlerinde yalnızca bir veri tüketimi ve iletimi için kullanılan, veritabanındaki herhangi bir verinin transfer nesnesidir/karşılığıdır/görünümüdür.

        // Farklar

        // ViewModel
        // Kullanıcıya sunulacak verinin view'e uygun/view'in beklediği şekilde tasarlanmış modelidir.
        // Veriyi görünüm/sunum/presentation için anlamlı hale getirir.
        // İşlevsel fonksiyonlar (metot) barındırabilir.
        // İçerisinde bir veya birden fazla DTO temsil edebilir.
        // DTO'ya nazaran daha karmaşıktır.

        // DTO (Data Transfer Object)
        // Bir verinin(genellikle veritabanından gelen verinin) transfer modellemesidir.Transfer edilecek olan ilgili verideki sadece ihtiyaç olunan dataları temsil eder.
        // Görünüm/sunum/presentation için kullanılabilir lakin bunun dışında uygulamanın herhangi bir katmanında çeşitli veri tüketimi ve transferi içinde kullanılmaktadır.
        // Herhangi bir fonksiyonellik barındırmaz.
        // Salt veriyi temsil eder.

        public IActionResult Index()
        {
            return View();
        }
    }
}
