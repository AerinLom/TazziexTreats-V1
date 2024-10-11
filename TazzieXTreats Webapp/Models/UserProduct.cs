using TazzieXTreats_Webapp.Models;

namespace TazzieXTreats_Webapp.Models
{
    public class UserProduct
    {
        public int UserId { get; set; } // Foreign key for UserProfile
        public int Id { get; set; } // Foreign key for Product
        public UserModel User { get; set; } // Navigation property
        public ProductModel Product { get; set; } // Navigation property
    }
}
