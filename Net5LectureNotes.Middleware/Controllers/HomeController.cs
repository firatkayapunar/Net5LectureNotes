using Microsoft.AspNetCore.Mvc;

namespace Net5LectureNotes.Middleware.Controllers
{
    // https://medium.com/@firatkayapunar adresi üzerinde detaylı konu anlatımı mevcut. (Chain of Responsibility Design Pattern ve Middlware Nedir?)

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
