using System.ComponentModel.DataAnnotations;

namespace ProductsApi.DTOs
{
    public class CreateProductRequest
    {

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name {  get; set; } = string.Empty;

        [Range(0.01, 999999999, ErrorMessage = "El precio debe ser mayor que cero")]
        public decimal Price { get; set; }
    }
}
