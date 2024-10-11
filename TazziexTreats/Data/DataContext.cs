using Microsoft.EntityFrameworkCore;
using TazziexTreats.Models;
namespace TazziexTreats.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define DbSet properties for each entity
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship for UserProduct entity
            modelBuilder.Entity<UserProduct>()
                .HasKey(up => new { up.UserId, up.Id }); // Composite key

            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserProducts) // One user can have many user products
                .HasForeignKey(up => up.UserId); // Foreign key

            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.Product)
                .WithMany(p => p.UserProducts) // One product can belong to many users
                .HasForeignKey(up => up.Id); // Foreign key

            base.OnModelCreating(modelBuilder); // Call base method for further configurations
        }

    }
}
