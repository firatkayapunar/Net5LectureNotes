using System.ComponentModel.DataAnnotations;

namespace Net5LectureNotes.Validation.Models.ModelMetadataTypes
{
    public class ProductMetadata
    {
        // Create Product sınıfının sorumluluğunu tek bir göreve indirgemek için burayı ve orayı ayırdık. Orası artık yalnızca veri taşıma görevini üstlenirken, burası model doğrulama için kullanılacak.

        // [ModelMetadataType(typeof(ProductMetadata))] kullanarak, artık Create Product sınıfının model doğrulama sınıfı olarak ProductMetadata sınıfını belirlemiş olduk.
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your product name.")]
        [StringLength(100, ErrorMessage = "Please enter the product name up to 100 characters.")]
        public string ProductName { get; set; } = string.Empty;
        public string EMail { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a correct e-mail address.")]
        public int Quantity { get; set; }
    }
}
