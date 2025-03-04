using Microsoft.AspNetCore.Mvc;

namespace Net5LectureNotes.FirstStep.Controllers
{
    // Controller sınıflarının isimlerinin sonuna Controller eki koyulması gelenekseldir.
    // Sıradan bir class'ı request alabilecek ve response döndürülebilir hale getirmek için o sınıfı Controller sınıfından inherit etmemiz gerekiyor.
    public class HomeController : Controller
    {
        // Controller sınıfları içerisinde istekleri karşılayan metotlara action metot denir.
        public IActionResult Index()
        {
            // return View(Create); => Belirtilen isimdeki view dosyasını render eder.

            return View();
        }
    }
}
