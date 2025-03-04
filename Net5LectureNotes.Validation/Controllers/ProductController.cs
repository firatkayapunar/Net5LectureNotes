using Microsoft.AspNetCore.Mvc;
using Net5LectureNotes.Validation.Models;

namespace Net5LectureNotes.Validation.Controllers
{
    // Validation : Bir değerin içinde bulunduğu şartlara uygun olması durumudur. Belirlenen koşullara ve amaca uygun olup olmama durumunun kontrol edilmesidir. Bu kontrollere göre verinin isleme tabi tutulması durumudur.

    // İki validation vardır . Biri Server Validation ise diğeri Client Validation'dır. İki taraf için de yapılmalıdır.

    public class ProductController : Controller
    {
        public IActionResult CreateProduct()
        {
            return View();
        }

        public IActionResult CreateProduct(CreateProduct product)
        {
            // ModelState, HTTP isteği sırasında formdan gelen verileri modelin veri tiplerine ve doğrulama kurallarına uygun olup olmadığını kontrol eder.
            // Eğer doğrulama başarısız olursa, ModelState.IsValid false döner ve hata mesajlarını içerir.

            if (ModelState.IsValid)
            {
                /*
                 Sürecin Adım Adım Özeti

                **********************************************************************************************************************
                 
                 1. İlk Ekran (GET İsteği):
                 
                 Controller: CreateProduct() GET action’ı çağrılır, boş veya varsayılan bir modelle return View(); yapılır.
                 View Render:
                    - Razor view derlenir.
                    - <input asp-for="ProductName" /> gibi tag helper’lar, modelin property’leriyle ilişkilendirilir.
                    - <span asp-validation-for="ProductName"></span> henüz hata olmadığı için boş kalır.
                 Sonuç: Temiz, hatasız bir form kullanıcıya sunulur.

                **********************************************************************************************************************

                 2. Formun Doldurulup Gönderilmesi (POST İsteği):
                 
                 Kullanıcı İşlemi: Kullanıcı formu doldurur ve “Gönder” butonuna basar.
                 Form Action: Form, asp-action="CreateProduct" ve asp-controller="Product" sayesinde ilgili POST action’a gönderilir.

                 İstemci Tarafı Validasyonu (Zorunlu Değil)
                 Client-side validasyon, kullanıcı deneyimini iyileştirmek ve sunucuya gereksiz istek gönderilmesini önlemek amacıyla kullanılır. Ancak, kesinlikle güvenlik açısından sunucu tarafı validasyonun yerini alamaz.

                 Script’lerin Rolü:
                jQuery, jquery.validate ve jquery.validate.unobtrusive script’leri, HTML elemanlarına otomatik olarak eklenen data-val, data-val-required gibi attributeleri okur. Bu attributeler sayesinde, form gönderilmeden önce kullanıcı tarafından girilen verilerin geçerliliği kontrol edilir. Hatalı veri varsa, bu script’ler formun sunucuya gönderilmesini engelleyerek, hata mesajlarını kullanıcıya gösterir.

                 **********************************************************************************************************************
                
                 3. POST İşlemi, Model Binding ve Sunucu Tarafı Validasyon:
                 
                 Form verileri, ilgili modele otomatik olarak bind edilir.
                 Modelde tanımlı doğrulama kuralları uygulanır; hatalı alanlar için ModelState’e hata mesajları eklenir.
                 Controller, if (ModelState.IsValid) kontrolü yapar:
                    - Eğer validasyon başarılıysa işleme devam edilir.
                    - Hatalı ise model, ModelState ile birlikte view’e geri gönderilir.

                **********************************************************************************************************************

                 4. Hataların View’de Gösterilmesi:
                 
                 ModelState Transferi: Controller’dan dönen model ile ModelState bilgisi view’e aktarılır.
                 Tag Helper’lar:
                    - <span asp-validation-for="PropertyName"></span> ilgili property’ye ait hata mesajını gösterir.
                    - <div asp-validation-summary="All"></div> tüm hata mesajlarını toplu şekilde listeler.
                 Sonuç: Form, hatalı girilmiş verilerle yeniden render edilir ve ilgili alanlarda hata mesajları görüntülenir.
                 
                 */

                return View(product);
            }

            return View();
        }
    }
}
