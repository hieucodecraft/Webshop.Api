using Microsoft.EntityFrameworkCore;
using Webshop.Api.Orders;
using Webshop.Api.Products;

namespace Webshop.Api
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
                
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Product");

            modelBuilder.Entity<Product>().HasData(SeedProducts);
        }

        private static readonly Product[] SeedProducts =
        {
            new() {Id =  Guid.NewGuid(), Name ="Product #1", Price = 100m },
            new() {Id =  Guid.NewGuid(), Name ="Product #2", Price = 200m },
            new() {Id =  Guid.NewGuid(), Name ="Product #3", Price = 300m },
            new() {Id =  Guid.NewGuid(), Name ="Product #4", Price = 400m },
            new() {Id =  Guid.NewGuid(), Name ="Product #5", Price = 500m },
        };
    }
}
