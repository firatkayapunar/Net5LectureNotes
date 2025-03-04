using Microsoft.AspNetCore.Mvc;

namespace Net5LectureNotes.ActionType.Controllers
{
    public class HomeController : Controller
    {
        #region ViewResult
        public ViewResult Index()
        {
            // Response olarak bir View dosyasını render etmemizi sağlayan action türüdür.
            return View();
        }
        #endregion

        #region JsonResult
        public JsonResult Create()
        {
            // Üretilen datayı JSON türüne dönüştürüp döndüren bir action türüdür.
            // Json metodu otomatik kendisi nesnemizi Json formatına çevirir.
            return Json(new { id = 1, });
        }
        #endregion

        #region EmptyResult
        public EmptyResult Update()
        {
            // Bazen gelen istekler neticesinde herhangi bir şey döndürmek istemeyebiliriz. Böyle bir durumda EmptyResult action türü kullanılabilir.
            return new EmptyResult();
        }
        #endregion

        #region ContentResult
        public ContentResult Delete()
        {
            // İstek neticesinde cevap olarak metinsel bir değer döndürmemizi sağlayan action türüdür.
            return Content("Sebepsiz boş yere ayrılacaksan.");
        }
        #endregion

        #region ActionResult
        public ActionResult GetById()
        {
            // Gelen bir istek neticesinde geriye döndürülecek action türleri'nin değişkenlik gösterebildiği durumlarda kullanılan bir action türüdür.
            return View();
        }
        #endregion

        #region IActionResult
        public IActionResult GetAll()
        {
            // Gelen bir istek neticesinde geriye döndürülecek action türleri'nin değişkenlik gösterebildiği durumlarda kullanılan bir action türüdür. ActionResult IActionResult'ı implement eder.
            return View();
        }
        #endregion
    }
}
