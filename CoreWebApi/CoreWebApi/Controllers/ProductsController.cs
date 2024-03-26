using CoreWebApi.DTO;
using CoreWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsContext _productsContext;
        public ProductsController(ProductsContext productsContext)
        {
            _productsContext = productsContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productsContext.products.Where(i => i.IsActive == true).Select(p => ProducToDto(p)).ToListAsync();

            return Ok(products);
        }
        [Authorize]
        [HttpGet("api/[controller]/{id}")]
        public async Task<IActionResult> GetProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var p = await _productsContext.products.Where(i => i.ProductId == id).Select(p => ProducToDto(p)).FirstAsync();
            if (p == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(p);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product entity)
        {
            _productsContext.products.Add(entity);
            await _productsContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = entity.ProductId }, entity);
        }

        [HttpPut("api/[controller]/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product entity)
        {
            if (id != entity.ProductId)
            {
                return BadRequest();
            }
            var product = await _productsContext.products.FirstOrDefaultAsync(i => i.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                product.ProductName = entity.ProductName;
                product.Price = entity.Price;
                product.IsActive = entity.IsActive;
                try
                {
                    await _productsContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return NotFound();
                }
                return NoContent();

            }
        }
        [HttpDelete("api/[controller]/{id}")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _productsContext.products.FirstOrDefaultAsync(i => i.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                _productsContext.products.Remove(product);
                try
                {
                    await _productsContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return NotFound();
                }
                return NoContent();
            }
        }
        private static ProductDTO ProducToDto(Product p)
        {
            var entity = new ProductDTO();
            if (p != null)
            {
                entity.ProductName = p.ProductName;
                entity.ProductName = p.ProductName;
                entity.Price = p.Price;

            }
            return entity;
        }
    }
}
