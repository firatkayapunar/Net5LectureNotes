using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Net5LectureNotes.Helper.Extensions
{
    public static class CustomHtmlHelper
    {
        public static IHtmlContent CustomTextBox(this IHtmlHelper htmlHelper, string name, string value)
        {
            // Bunun View tarafında değil de burada yazarak birden çok yerde aynı şeyi kullanabilir hale geldik.

            // ASP.NET Core MVC, buradaki anonim nesneyi HTML öğesine attribute olarak dönüştürür. Bu yöntem, class, id, placeholder, data-* gibi ek özellikleri hızlıca tanımlamayı sağlar.
            // class="form-input" şeklinde bir CSS sınıfı eklemek için kullanılıyor. 
            return htmlHelper.TextBox(name, value, new
            {
                @class = "form-input"
            });
        }
    }
}
