using Microsoft.AspNetCore.Mvc;

namespace Net5LectureNotes.DataTransportControl.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
