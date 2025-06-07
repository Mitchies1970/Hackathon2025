namespace Hackathon2025.DTOs
{
    public class Product(string name, string description)
    {
        public int Id { get; set; }
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
    }
}
