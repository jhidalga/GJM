namespace GJM.Data
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime RegistrationDate  { get; set; } = DateTime.MinValue;
        public bool IsRented { get; set; } = false;
        public DateTime? ReturnDate { get; set; }
        public virtual User? User { get; set; }
    }
}
