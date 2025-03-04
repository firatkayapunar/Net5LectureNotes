using Microsoft.AspNetCore.Mvc;

namespace Net5LectureNotes.Validation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
