using Microsoft.EntityFrameworkCore;
using SnappFood.Domain.Orders;
using SnappFood.Domain.Products;
using SnappFood.Domain.Users;
using SnappFood.Persistence.EF.Products;

namespace SnappFood.Persistence.EF
{
    public class SnappContext : DbContext
    {
        public SnappContext(DbContextOptions<SnappContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductEntityTypeConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
