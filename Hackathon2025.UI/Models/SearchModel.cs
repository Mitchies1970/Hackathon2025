using Hackathon2025.DTOs;

namespace Hackathon2025.UI.Models
{
    public record SearchModel(string SearchText, bool IsError = false, string ErrorMessage = "")
    {
        public List<Product> ProductsFound { get; set; } = new List<Product>();
    }
}
