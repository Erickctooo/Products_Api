using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.DTOs;
using ProductsApi.Models;
using System.Runtime.ConstrainedExecution;

namespace ProductsApi.Services
{
    public class ProductService : IProductService
    {

        private readonly ProductsDbContext _context;

        public ProductService(ProductsDbContext _context) {

            this._context = _context;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateAsync(Product product)
        {
             _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Product? product = await _context.Products.FindAsync(id);

            if (product != null) 
            {
                _context.Products.Remove(product);

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> UpdateAsync(int id , Product updateProduct)
        {

            Product? product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return false;
            }

            product.Name = updateProduct.Name;
            product.Price = updateProduct.Price;
            
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> PatchAsync(int id , PatchProductRequest patchProduct)
        {
            Product? product = await _context.Products.FindAsync(id);

            if(product == null)
            {
                return false;
            }

            if(patchProduct.Name != null)
            {
                product.Name = patchProduct.Name;
            }

            if (patchProduct.Price.HasValue)
            {
                product.Price = patchProduct.Price.Value;
            }

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
