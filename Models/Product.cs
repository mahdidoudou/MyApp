using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 999999)]
        public decimal Price { get; set; }

        public string Brand { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public int Stock { get; set; }

        public bool IsAvailable { get; set; } = true;

        public string ImageUrl { get; set; } = string.Empty;
    }
}