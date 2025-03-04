using Microsoft.AspNetCore.Mvc;

namespace Net5LectureNotes.Route.Controllers
{
    [Route("[controller]/[action]")]
    //[Route("Dashboard/[action]")] => Özel isimlendirme ile direkt controller ile eşleştirebiliriz.
    //[Route("Dashboard")] => Özel isimlendirme ile yine direkt controller ile eşleştirebiliriz. Özel Action isimlendirmesini ise Action metodunun üzerinde yapacağız.
    public class HomeController : Controller
    {
        [Route("[action]")] // Default
        [Route("ThisIndex")] // Custom
        public IActionResult Index()
        {
            return View();
        }

        [Route("ThisIndex/{id}")]
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
