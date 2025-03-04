using Microsoft.AspNetCore.Mvc;
using Net5LectureNotes.DataTransportControl.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace Net5LectureNotes.DataTransportControl.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name="Product 1", Quantity =1},
                new Product { Id = 2, Name="Product 2", Quantity =2},
                new Product { Id = 3, Name="Product 3", Quantity =3}
            };

            #region Veri Tasima Kontrolleri

            #region ViewBag
            // View'a taşınacak datayı dynamic bir şekilde tanımlanan bir değişkenle taşımamızı sağlayan bir veri taşıma kontrolüdür.
            ViewBag.Products = products;

            #endregion ViewData

            #region ViewData
            // ViewBag'de olduğu gibi actiondaki datayı view'e taşımamızı sağlayan bir kontroldür.
            ViewData["products"] = products;
            #endregion

            #region TempData
            // ViewBag'de olduğu gibi actiondaki datayı view'e taşımamızı sağlayan bir kontroldür. Ama bu değer Session içerisine alıncağı için bunu List (products) gibi özel complex bir tiple ekleyemeyiz. Onun için bu nesneyi serialize etmemiz gerekiyor. Onun için de JsonSerializer denilen sınıfımızı kullanabiliriz. Unutmayalım JSON özünde string bir ifadedir.
            string data = JsonSerializer.Serialize(products);
            TempData["products"] = data;
            #endregion

            #region Model Bazlı Veri Gonderimi
            // return View(products);
            #endregion

            // 🔹 TempData ve RedirectToAction’ın Çalışma Mantığı

            // 1️. İlk Aşama: Kullanıcı Index Metoduna HTTP GET İsteği Gönderir
            
            // Kullanıcı tarayıcıdan / Product / Index sayfasına gider.
            // Tarayıcı, sunucuya bir HTTP GET isteği gönderir.
            // Sunucu, Index metodunu çalıştırır.
            // TempData["products"] içine veri eklenir.
            // ViewBag ve ViewData da burada oluşturulabilir, ancak sadece bu isteğe özeldir.
            // RedirectToAction çağrılır ve yönlendirme başlatılır.

            // 2️. Sunucu Tarayıcıya Redirect Yanıtı Döner
            
            // RedirectToAction("Index2") çalıştığında, sunucu kullanıcıyı yeni bir URL’ye yönlendirir.
            // Sunucu doğrudan yönlendirme yapmaz, tarayıcıya "Lütfen yeni bir istekte bulun" der.
            // Sunucu 302 Found HTTP yanıtı döner ve yeni adresi(/ Product / Index2) bildirir.
            // TempData içindeki veriler, Response içine Cookie olarak eklenir ve tarayıcıya gönderilir.
            // ViewBag ve ViewData ise Response içinde saklanmaz, bu yüzden bir sonraki istekte kaybolacaktır.

            // 3️. Tarayıcı Index2 Metodu İçin Yeni Bir HTTP GET İsteği Yapar
               
            // Tarayıcı, 302 Found yanıtını aldığında, belirtilen / Product / Index2 URL’sine yeni bir HTTP GET isteği başlatır.
            // Tarayıcı, önceki istekte aldığı TempData Cookie’sini bu yeni isteğe ekler.
            // ViewBag ve ViewData artık bu istekte mevcut değildir, çünkü yeni bir HTTP isteği başlamıştır.
            // Ancak TempData hala korunmaktadır, çünkü tarayıcı Cookie içindeki veriyi sunucuya geri gönderir.

            // 4️. Sunucu Index2 Metodunu Çalıştırır
            
            // Sunucu, yeni gelen isteği alır ve Index2 metodunu çalıştırır.
            // ASP.NET Core, tarayıcının gönderdiği TempData Cookie’sini okur ve deserialize eder.
            // TempData içindeki veriler tekrar kullanılabilir hale gelir.
            // TempData, bu istekte ilk kez okunduğu anda otomatik olarak silinir.
            // View içinde TempData kullanıldığında, içeriği ekrana yazdırılır ve yanıt olarak tarayıcıya gönderilir.

            return RedirectToAction("Index2", "Product");

            #endregion
        }

        public IActionResult Index2()
        {
            var dtc = ViewBag.Products; // null
            var dtc1 = ViewData["products"]; // null

            // Index metodu içerisinde serialize ettiğimiz değeri burada deserialize ediyoruz.
            var data = TempData["products"].ToString();
            var dtc2 = JsonSerializer.Deserialize<List<Product>>(data);
            ViewData["products"] = dtc2;

            return View();
        }

        // View Model
        public IActionResult GetProducts()
        {
            var product = new Product
            {
                Id = 1,
                Name = "A Product",
                Quantity = 1,
            };

            var user = new User
            {
                Id = 1,
                FirstName = "Fırat",
                SurName = "Kayapunar",
            };

            var userProduct = new UserProduct
            {
                Product = product,
                User = user
            };

            return View(userProduct);
        }

        // Tupple Object
        public IActionResult GetProductsWithTuppleObject()
        {
            var product = new Product
            {
                Id = 1,
                Name = "A Product",
                Quantity = 1,
            };

            var user = new User
            {
                Id = 1,
                FirstName = "Fırat",
                SurName = "Kayapunar",
            };

            var userProduct = (product, user);

            return View(userProduct);
        }

        [HttpPost]
        public IActionResult CreateProduct([Bind(Prefix = "Item1")] Product product, [Bind(Prefix = "Item2")] User user)
        {
            return View();
        }
    }
}
