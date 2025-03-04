using Microsoft.AspNetCore.Mvc;

namespace Net5LectureNotes.Helper.Controllers
{
    public class HomeController : Controller
    {
        #region UrlHelpers

        // ASP.NET Core MVC uygulamalarında URL oluşturmak için yardımcı metotlar içeren ve o anki URL'ye dair bilgi veren bir sınıftır.

        #region Metotlar

        #region Action
        // Verilen Controller ve Action’a ait URL oluşturmayı sağlayan metottur.

        // Kullanım:
        // Url.Action("index", "product", new { id = 5 })

        // Bu kod, aşağıdaki URL'yi üretir:
        // product/index/5
        #endregion

        #region ActionLink
        // Verilen Controller ve Action’a ait tam URL oluşturmayı sağlayan metottur.

        // Kullanım:
        // Url.ActionLink("index", "product", new { id = 5 })

        // Bu kod, aşağıdaki tam URL'yi üretir:
        // https://localhost:5001/product/index/5
        #endregion

        #region   Content
        // Genellikle CSS ve Script gibi statik dosya dizinlerini programatik olarak belirtmek için kullanılır.

        // Kullanım:
        // Url.Content("~/site.css")

        // Bu kod, aşağıdaki yolu üretir:
        // site.css
        #endregion

        #region RouteUrl
        // Mimaride tanımlı olan Route isimlerine uygun bir şekilde URL oluşturan bir metottur.

        // Kullanım:
        // Url.RouteUrl("Default")

        // Bu kod, aşağıdaki URL'yi üretir:
        // /Product/GetProducts
        #endregion

        #endregion

        #region Propertyler

        #region ActionContext
        // O anki URL’e dair tüm bilgilere erişmemizi sağlayan bir property'dir.
        // Url.ActionContext
        #endregion

        #endregion

        #endregion

        #region HtmlHelpers
        // Server tarafında HTML oluşturmayı kolaylaştırır.
        // .cshtml dosyalarının render edilmesini sağlar.
        // O anki context hakkında bilgi edinmemizi sağlar.
        // Veri taşıma kontrollerine(ViewBag, ViewData, TempData) erişim sağlar.

        #region Metotlar

        #region Html.Partial
        // Html.Partial() metodu, başka bir View dosyasını (.cshtml) mevcut sayfa içerisine dahil etmeyi sağlar.

        // <div style = "border-top-color:ActiveBorder" >
        //     @Html.Partial("~/Views/Product/Index.cshtml")
        // </ div >

        // Bu kod, /Views/Product/Index.cshtml dosyasını mevcut sayfaya dahil eder.
        // Static olarak çalışır, yani direkt ilgili View dosyasını çağırır, bir Controller Action çağrısı yapmaz.
        // Gömülü HTML içeriği gibi davranır ve dinamik veri ekleyebilir.

        // Eğer Partial View içerisine model göndermek istiyorsak:
        // @Html.Partial("~/Views/Product/Index.cshtml", Model)
        // Bu şekilde, Index.cshtml içinde Model kullanılabilir.

        #endregion

        #region Html.RenderPartial
        // Html.RenderPartial() metodu, başka bir View dosyasını (.cshtml) mevcut sayfa içerisine dahil etmeyi sağlar.

        // <div style = "border-top-color:ActiveBorder" >
        //     @{Html.RenderPartial("~/Views/Product/Index.cshtml");}
        // </ div >
        #endregion

        #region Html.ActionLink
        // Html.ActionLink, ASP.NET Core MVC’de bir URL oluşturup, o URL’ye bağlı bir HTML<a> etiketi üretir.

        // @Html.ActionLink("Anasayfa", "Index", "Home")
        // Bu kod, aşağıdaki HTML çıktısını üretir:
        // <a href = "/Home/Index" > Anasayfa </ a >
        #endregion

        #region Html Form Metotları

        // Önemli Form Metotları
        // Html.BeginForm() → Form başlangıcını oluşturur.
        // Html.CheckBox("cb") → Checkbox(onay kutusu) oluşturur.
        // Html.TextBox("txt") → Text input(yazı alanı) oluşturur.
        // Html.Display("display") → Veriyi sadece görüntülemek için kullanılır.
        // Html.Password("pwd") → Şifre giriş alanı oluşturur.
        // Html.TextArea("area") → Çok satırlı metin alanı oluşturur.
        // Html.ValidationMessage("vldt") → Form doğrulama mesajlarını gösterir.

        // Örnek Kullanım
        // @using(Html.BeginForm("GetProducts", "Product", FormMethod.Post))
        // {
        //     @Html.CheckBox("cb")
        //     @Html.TextBox("txt")
        //     @Html.Password("pwd")
        //     @Html.TextArea("area")
        //     @Html.ValidationMessage("vldt")
        // }

        // Üretilen HTML Çıktısı
        // <form action = "/product/getproducts" method="post">
        //     <input id = "cb" name="cb" type="checkbox" value="true">
        //     <input id = "txt" name="txt" type="text" value="">
        //     <input id = "pwd" name="pwd" type="password">
        //     <textarea id = "area" name="area"></textarea>
        //     <span class="field-validation-valid" data-valmsg-for="vldt" data-valmsg-replace="true"></span>
        // </form>

        #endregion

        #endregion

        #endregion

        #region TagHelpers

        // HtmlHelpers’larda ki programatik yapılanma, programlama bilmeyen tasarımcıların çalışmasını imkansız hale getirmekteydi.TagHelpers’lar ile buradaki kusur giderildi ve tasarımcılar açısından programlama bilgisine ihtiyaç duyulmaksızın çalışma yapılabilir nitelik kazandırdı.

        // HtmlHelpers ile oluşturulan HTML nesnesinin attribute’ları htmlAttribute parametresi üzerinden anonim nesne ile tanımlanmaktadır. Bu durum hem bellek optimizasyonu açısından hem de kod maliyeti açısından oldukça zararlıdır.TagHelpers’lar bu maliyeti ortadan kaldırmakta ve HTML nesnelerine sadece ilgili attribute’ları normal sözdizimiyle vermekle ilgilenmektedir.
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomHtmlHelper()
        {
            return View();
        }

        public IActionResult CustomTagHelper()
        {
            return View();
        }
    }
}
