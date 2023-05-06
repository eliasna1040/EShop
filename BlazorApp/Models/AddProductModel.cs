using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class AddProductModel
    {
        [Required(ErrorMessage = "Feltet skal udfyldes")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Feltet skal udfyldes")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Feltet skal udfyldes")]
        public double? Price { get; set; }
        [Required(ErrorMessage = "Feltet skal udfyldes")]
        public bool? Disabled { get; set; } = false;
        public byte[]? Image { get; set; }
        [Required(ErrorMessage = "Feltet skal udfyldes")]
        public int? ManufacturerId { get; set; }
        [Required(ErrorMessage = "Feltet skal udfyldes")]
        public int? CategoryId { get; set; }
    }
}
