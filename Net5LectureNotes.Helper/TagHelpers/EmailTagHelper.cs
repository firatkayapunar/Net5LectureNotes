using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Net5LectureNotes.Helper.TagHelpers
{
    // [HtmlTargetElement("mail")]: <mail> şeklinde özel bir HTML etiketi oluşturulmasını sağlar.
    [HtmlTargetElement("mail")]
    public class EmailTagHelper : TagHelper
    {
        // Mail: Kullanıcının e-posta adresini belirtmesini sağlar.
        // Display: Linkin görünmesini istediğimiz metni tutar.
        // Örneğin, <mail mail = "test@example.com" display= "İletişime Geçin" ></ mail > şeklinde kullanılabilir.
        public string Mail { get; set; }
        public string Display { get; set; }

        //Bu metot, <mail> etiketini<a href = "mailto:..." > ...</a> şeklinde bir HTML bağlantısına dönüştürür.
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // context <mail mail="test@example.com" display="Bize Ulaşın"></mail> ifadesindeki değerleri getiriyor.

            output.TagName = "a"; // HTML <a> (link) etiketi oluşturuluyor
            output.Attributes.Add("href", $"mailto:{Mail}"); // href özelliği e-posta adresi olarak atanıyor
            output.Content.Append(Display); // İçeriğe "Display" değeri ekleniyor
        }
    }
}
