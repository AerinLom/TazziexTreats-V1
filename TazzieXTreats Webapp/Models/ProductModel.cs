using TazzieXTreats_Webapp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TazzieXTreats_Webapp.Models
{
    public class ProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary key
        public string Name { get; set; } // Product name
        public string Type { get; set; } // Type of product (e.g., Dessert, Bread, Pastry)
        public decimal Price { get; set; } // Price of the product
        public string Description { get; set; } // Description of the product
        public string Picture { get; set; } // URL to the product picture
        public ICollection<UserProduct> UserProducts { get; set; }
    }
}