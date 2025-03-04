using Microsoft.AspNetCore.Mvc;

namespace Net5LectureNotes.ActionType.Controllers
{
    // [NonController] => Böyle bir şey de var.
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            GetById();
            return View();
        }

        // Controller içerisinde NonAction attribute'u ile işaretlenen metotlar dışarıdan request karşılamazlar.
        // Sadece algoritma barındıran iş mantığı yürüten bir metottur. Ayrıca bu tercih edilen de bir şey değildir.
        [NonAction]
        public void GetById()
        { }
    }
}
