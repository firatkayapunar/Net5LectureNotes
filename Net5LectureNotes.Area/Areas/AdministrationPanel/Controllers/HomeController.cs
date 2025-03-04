using Microsoft.AspNetCore.Mvc;

namespace Net5LectureNotes.Area.Areas.AdministrationPanel.Controllers
{
    [Area("AdministrationPanel")]
    public class HomeController : Controller
    {
        // Web uygulamasında farklı işlevsellikleri ayırmak için kullanılan özelliktir.
        // Bu farklı işlevsellikler için farklı katmanda, bir route ayarlamamızı sağlayan ve bu katmanda o işleve özel yönetim sergileyen birr yapılanmadır.
        // Herbir area, içerisinde View, Controller ve Model katmanı barındırabilir.
        // Böylece Asp.NET Core uygulamalarında yönetilebilir küçük ve işlevsel gruplar oluşturulabilir.
        
        // Area içerisindeki comtroller Area Attribute'u ile işaretlenmelidir.
        // Böylece ilgili alanın uygulamadaki adı resmiyette belirtilmiş olacaktır.
        // Aksi taktirde farklı area'larda ki controller'lardan aynı isimde olanların çakışma ihtimalleri vardır.

        // Her bir area, içersindeki controller'lara erişim için farklı bir route sağlanmaktadır.
        // Dolayısıyla bu route'ların tarafımızca tasarlanması gerekmektedir.
        public IActionResult Index()
        {
            return View();
        }
    }
}
