namespace Net5LectureNotes.ViewModelAndDTO.Models
{
    public class Personnel
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty ;
        public string Position { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
