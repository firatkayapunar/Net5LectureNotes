using Microsoft.AspNetCore.Mvc;
using Net5LectureNotes.Validation.Models.ModelMetadataTypes;

namespace Net5LectureNotes.Validation.Models
{
    [ModelMetadataType(typeof(ProductMetadata))]
    public class CreateProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string EMail { get; set; }
        public int Quantity { get; set; }
    }
}
