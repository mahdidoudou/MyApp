using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "admin123", Role = "Admin", FullName = "Admin User", Email = "admin@store.com" },
                new User { Id = 2, Username = "customer", Password = "customer123", Role = "Customer", FullName = "John Doe", Email = "john@store.com" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "iPhone 15 Pro", Brand = "Apple", Category = "Smartphones", Description = "Latest Apple flagship phone", Price = 999, Stock = 20, IsAvailable = true, ImageUrl = "https://via.placeholder.com/300" },
                new Product { Id = 2, Name = "Samsung Galaxy S24", Brand = "Samsung", Category = "Smartphones", Description = "Latest Samsung flagship phone", Price = 899, Stock = 15, IsAvailable = true, ImageUrl = "https://via.placeholder.com/300" },
                new Product { Id = 3, Name = "Xiaomi 14", Brand = "Xiaomi", Category = "Smartphones", Description = "Latest Xiaomi flagship phone", Price = 699, Stock = 30, IsAvailable = true, ImageUrl = "https://via.placeholder.com/300" }
            );
        }
    }
}