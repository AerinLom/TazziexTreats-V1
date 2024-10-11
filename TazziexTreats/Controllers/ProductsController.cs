using Microsoft.AspNetCore.Mvc;
using TazziexTreats.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TazziexTreats.Models;

namespace FitnessFormula_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // GET: api/products/search/{name}
        [HttpGet("search/{name}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Product name cannot be empty.");
            }

            var products = await _context.Products
                .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                .ToListAsync();

            if (products == null || products.Count == 0)
            {
                return NotFound("No products found.");
            }

            return products;
        }

        // GET: api/products/type/{type}
        [HttpGet("type/{type}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByType(string type)
        {
            // Validate type
            if (string.IsNullOrWhiteSpace(type))
            {
                return BadRequest("Product type cannot be empty.");
            }

            var products = await _context.Products
                .Where(p => p.Type.ToLower() == type.ToLower()) // Case-insensitive comparison
                .ToListAsync();

            if (products == null || products.Count == 0)
            {
                return NotFound("No products found for the specified type.");
            }

            return Ok(products);
        }

        [HttpGet("last")]
        public async Task<ActionResult<IEnumerable<Product>>> GetLastTwoProducts()
        {
            var products = await _context.Products
                .OrderByDescending(p => p.Id) // Adjust this based on your primary key
                .Take(2) // Take the last 2 entries
                .ToListAsync();

            if (products == null || products.Count == 0)
            {
                return NotFound("No products found in the database.");
            }

            return Ok(products);
        }
    }
}
