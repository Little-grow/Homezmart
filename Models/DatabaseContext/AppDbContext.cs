using Homezmart.Models.Categories;
using Homezmart.Models.Orders;
using Homezmart.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Homezmart.Models.DatabaseContext
{
    public class AppDbContext : IdentityDBContext
    {   
        public AppDbContext() :
            base("name=AppDbContext")
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Subcategories)
                .WithOne()
                .HasForeignKey(s => s.CategoryId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne()
                .HasForeignKey(p => p.CategoryId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Subcategory>()
                .HasMany(s => s.Products)
                .WithOne()
                .HasForeignKey(p => p.SubcategoryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Subcategory> Subcategories { get; internal set; }
    }
}