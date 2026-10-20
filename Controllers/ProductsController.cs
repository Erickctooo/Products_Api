using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.DTOs;
using ProductsApi.Models;
using ProductsApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productsService;

        public ProductsController(IProductService _productsService)
        {
            this._productsService = _productsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {

            List<Product> products = await _productsService.GetProductsAsync();
            
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {

            Product? product = await _productsService.GetProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }


        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(CreateProductRequest request)
        {


            Product product = new Product { Name = request.Name, Price = request.Price };


            await _productsService.CreateAsync(product);
            

            return CreatedAtAction(
                nameof(GetProduct),
                new { id = product.Id },
                product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {


           bool delete = await _productsService.DeleteAsync(id);

            if(!delete) { return NotFound(); }

            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> updateProduct(UpdateProductRequest request, int id)
        {

            Product updateProduct = new Product
            {
                Name = request.Name,
                Price = request.Price
            };

            bool update = await _productsService.UpdateAsync(id, updateProduct);

            if (!update)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> patchProduct(PatchProductRequest request, int id)
        {

            bool patch = await _productsService.PatchAsync(id, request);

            if (!patch)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
