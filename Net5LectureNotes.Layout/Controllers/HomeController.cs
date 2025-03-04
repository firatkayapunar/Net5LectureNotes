using Microsoft.AspNetCore.Mvc;

namespace Net5LectureNotes.Layout.Controllers
{
    public class HomeController : Controller
    {
        // Layout: Sayfadan sayfaya gezinirken kullanıcıya tutarlı bir deneyim sağlayan ortak sayfa taslağıdır.
        public IActionResult Index()
        {
            return View();
        }
    }
}
