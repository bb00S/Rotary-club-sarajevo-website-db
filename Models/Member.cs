namespace RotaryClub.Models
{ 
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get;set; }
        public string? Website { get; set; }
        public string PhotoUrl { get;set; }
        public bool Honorary { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
