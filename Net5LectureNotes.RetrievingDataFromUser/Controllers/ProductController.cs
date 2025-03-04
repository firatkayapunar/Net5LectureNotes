using Microsoft.AspNetCore.Mvc;
using Net5LectureNotes.RetrievingDataFromUser.Models;

namespace Net5LectureNotes.RetrievingDataFromUser.Controllers
{
    public class ProductController : Controller
    {
        #region Form
        [HttpPost]
        public IActionResult CreateProduct(CreateProduct createProduct)
        {
            // Parametrede bekleyen değer ile View'ın modeli farklı olabilir. Önemli olan oradaki name değerleri ile bu parametredeki modelin içindeki property isimlerinin eşleşmesidir.
            return View();
        }

        // [HttpPost]
        // public IActionResult CreateProduct(IFormCollection datas)
        // {
        //     Gelen değerler key - value şeklinde tutulur.
        //     var quantity = datas["quantity"];
        //     return View();
        // }
        #endregion

        #region Query String
        // Query String : Güvenlik gerektirmeyen bilgilerin URL üzerinden taşınması için kullanılan yapılanmadır.

        public IActionResult GetProducts(string name) // ? name
        {
            // Request yapılan endponit'e query string parametresi eklenmiş mi eklenmemiş mi bununla ilgili bilgi verir.
            var queryString = Request.QueryString;

            // IQueryCollection bir dictionary benzeri koleksiyon olduğu için bir sorgu parametresine aşağıdaki gibi erişebiliriz:
            // string value = Query["parametreAdi"];

            // Örnek:
            // Eğer bir HTTP isteğinde şu URL varsa:

            // https://example.com/api/products?category=electronics&brand=samsung

            // Bu isteğin Query koleksiyonuna aşağıdaki gibi erişebiliriz:
            // string category = Query["category"]; => "electronics"
            // string brand = Query["brand"]; => "samsung"
            return View();
        }
        #endregion

        #region Route Parameter
        public IActionResult Get(string name)
        {
            // Değer yakalama işlemi Query String ile aynıdır.
            // Kimlik değerleri için bu uygundur. Id gibi.
            return View();
        }
        #endregion
    }
}
