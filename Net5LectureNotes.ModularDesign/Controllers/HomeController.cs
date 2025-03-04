using Microsoft.AspNetCore.Mvc;

namespace Net5LectureNotes.ModularDesign.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
