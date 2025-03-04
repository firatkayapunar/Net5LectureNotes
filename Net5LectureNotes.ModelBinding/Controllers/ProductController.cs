using Microsoft.AspNetCore.Mvc;
using Net5LectureNotes.ModelBinding.Models;

namespace Net5LectureNotes.ModelBinding.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult GetProducts()
        {
            // Burada bir Product nesnesi oluşturup View içine gönderdiğimizde bu değerler bind edilecek. Yani iki taraflı binding mevcut. Burada dediğimi anlamak için Create Product metodunu inceleyebiliriz.

            // View İçine Model Gönderme Süreci
            // 1️. Kullanıcı bir GET isteği yapar.
            // 2️. Controller içinde bir model nesnesi oluşturulur.
            // 3️. Model, View'e parametre olarak gönderilir.
            // 4️. View içinde, bu model verileri kullanılarak HTML oluşturulur.
            // 5️. Kullanıcıya HTML sayfası, modelin verileriyle doldurulmuş şekilde döndürülür.

            // Not: Model Binding mekanizması burada çalışmaz, çünkü Request'ten veri alınmıyor! ASP.NET Core burada "Model Binding" değil, "View'a Model Aktarma" mekanizmasını kullanıyor.
            return View();
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProduct createProduct)
        {
            // 1️. Kullanıcı, formu doldurup "Kaydet" butonuna bastığında, POST isteği oluşur.
            // 2️. Form verileri HTTP Request Body içinde gönderilir(form - data veya JSON olarak).
            // 3️. Model Binding mekanizması, HTTP isteğinde (Request) gelen verileri alır ve Product modelindeki ilgili property’lerle eşleştirir.
            // 4️. Controller'daki CreateProduct(Product product) metoduna, otomatik olarak doldurulmuş bir Product nesnesi gelir.

            return View();
        }
    }
}
