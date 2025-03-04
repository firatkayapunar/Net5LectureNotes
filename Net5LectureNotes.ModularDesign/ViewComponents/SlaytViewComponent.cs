using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Net5LectureNotes.ModularDesign.ViewComponents
{
    public class SlaytViewComponent : ViewComponent
    {
        // ViewComponent artık kendi Model’ini kendi oluşturuyor!
        // Controller’dan ViewData göndermeye gerek yok!
        public IViewComponentResult Invoke()
        {
            var images = new List<string> { "img1.jpg", "img2.jpg", "img3.jpg" };

            return View(images); // Model doğrudan ViewComponent içinde oluşturuluyor!
        }
    }
}
