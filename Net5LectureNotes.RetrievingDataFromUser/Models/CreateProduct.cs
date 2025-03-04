namespace Net5LectureNotes.RetrievingDataFromUser.Models
{
    public class CreateProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
