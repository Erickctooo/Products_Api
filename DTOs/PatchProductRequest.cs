using System.ComponentModel.DataAnnotations;

namespace ProductsApi.DTOs
{
    public class PatchProductRequest
    {
        
        [StringLength(100, MinimumLength = 1)]
        public string? Name { get; set; } 

        [Range(0.01, 999999999, ErrorMessage = "El precio debe ser mayor que cero")]
        public decimal? Price { get; set; }
    }
}
