using Microsoft.AspNetCore.Mvc;

namespace Net5LectureNotes.ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
