namespace TazziexTreats.Models
{
    public class UserCart
    {
        public int CartId { get; set; } // Primary Key
        public int UserId { get; set; } // Foreign Key for User
        public int Id { get; set; } // Foreign Key for Product

        // Navigation Properties (optional)
        public virtual UserProfile User { get; set; }
        public virtual Product Product { get; set; }
    }
}
