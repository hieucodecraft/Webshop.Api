using Microsoft.EntityFrameworkCore;
using Webshop.Api.Orders;

namespace Webshop.Api
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
        {
                
        }

        public DbSet<Order> Orders{ get; set; }
        public DbSet<LineItem> LineItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Order");

            modelBuilder.Entity<Order>()
                .HasMany(order => order.LineItems)
                .WithOne()
                .HasForeignKey(lineItem => lineItem.ProductId);
        }
    }
}
