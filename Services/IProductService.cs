using ProductsApi.DTOs;
using ProductsApi.Models;

namespace ProductsApi.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();

        Task<Product?> GetProductAsync(int id);

        Task<Product> CreateAsync(Product product);

        Task<bool> UpdateAsync(int id, Product updatedProduct);

        Task<bool> PatchAsync(int id, PatchProductRequest request);

        Task<bool> DeleteAsync(int id);
    }
}
  