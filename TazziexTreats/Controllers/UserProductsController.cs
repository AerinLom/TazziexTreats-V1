using Microsoft.AspNetCore.Mvc;
using TazziexTreats.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TazziexTreats.Data;

namespace TazziexTreats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserCart/MyCart?userId={userId}
        [HttpGet("MyCart")]
        public async Task<IActionResult> GetMyCart(int userId)
        {
            // Validate userId
            if (userId <= 0)
            {
                return BadRequest("Invalid user ID.");
            }

            try
            {
                // Retrieve user cart items including related product details using EF Core Include
                var userCartItems = await _context.UserProducts
                                                  .Include(uc => uc.Product)
                                                  .Where(uc => uc.UserId == userId)
                                                  .ToListAsync();

                // Extract products from UserCart and return as a list
                var products = userCartItems.Select(uc => new ProductDTO
                {
                    Id = uc.Product.Id,
                    Name = uc.Product.Name,
                    Price = uc.Product.Price,
                    Picture = uc.Product.Picture,
                    Description = uc.Product.Description,
                    Type = uc.Product.Type
                    // Map other fields as necessary
                }).ToList();

                return Ok(products); // Return list of products associated with the user
            }
            catch (Exception ex)
            {
                // Log and return 500 Internal Server Error for any exceptions
                // Example: _logger.LogError(ex, "Error occurred while fetching user cart");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/UserCart
        [HttpPost]
        public async Task<IActionResult> AddToCart(UserProductDto userProductDto)
        {
            // Validate model state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Create a new UserCart instance with userId and productId from DTO
                var cartItem = new UserProduct
                {
                    UserId = userProductDto.UserId,
                    Id = userProductDto.Id
                };

                // Add and save the new UserCart entity to the database
                _context.UserProducts.Add(cartItem);
                await _context.SaveChangesAsync();

                return Ok("Product added to cart successfully!"); // Return success message
            }
            catch (Exception ex)
            {
                // Log and return 500 Internal Server Error for any exceptions
                // Example: _logger.LogError(ex, $"Failed to add product to cart: {ex.Message}");
                return StatusCode(500, $"Failed to add product to cart: {ex.Message}");
            }
        }
        [HttpDelete("ClearCart")]
        public async Task<IActionResult> ClearCart(int userId)
        {
            if (userId <= 0)
            {
                return BadRequest("Invalid user ID.");
            }

            try
            {
                // Find all cart items for the given userId
                var userCartItems = _context.UserProducts.Where(uc => uc.UserId == userId);

                if (!userCartItems.Any())
                {
                    return NotFound("No products found in the user's cart.");
                }

                // Remove all found items
                _context.UserProducts.RemoveRange(userCartItems);
                await _context.SaveChangesAsync();

                return Ok("Cart cleared successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to clear cart: {ex.Message}");
            }
        }
    }
}
