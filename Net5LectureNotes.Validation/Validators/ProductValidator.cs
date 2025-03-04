using FluentValidation;
using Net5LectureNotes.Validation.Models;

namespace Net5LectureNotes.Validation.Validators
{
    public class ProductValidator : AbstractValidator<CreateProduct>
    {
        // Bu validator'ü yazdıktan ve Startup.cs dosyasında gerekli tanımlamayı yaptıktan sonra ek bir işlem yapmamıza gerek yok. Controller tarafında ModelState üzerinde doğrulama kontrollerimizi gerçekleştirebiliriz. Mimari, uygulamaya gelen modellere karşılık ilgili validator'ları (eğer tanımlıysa) otomatik olarak devreye sokacaktır. Doğrulama sonuçları, ModelState üzerinden erişilebilir olacaktır.
        // Böyle yaparak ViewModel'in sorumluluğunu teke düşürmüş olduk. Başka bir çözüm olarak bundan önce ModelMetadataType kullanmıştık.
        public ProductValidator()
        {
            RuleFor(x => x.EMail).NotNull().WithMessage("Email cannot be empty!");
            RuleFor(x => x.EMail).EmailAddress().WithMessage("Please enter a valid email.");

            RuleFor(x => x.ProductName).NotNull().NotEmpty().WithMessage("Please do not leave the product name empty.");
            RuleFor(x => x.ProductName).MaximumLength(100).WithMessage("Please do not exceed 100 characters for the product name.");
        }
    }
}
