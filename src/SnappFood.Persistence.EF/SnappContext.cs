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
            modelBuilder.Entity<User>().HasData(SeedUserInformation());

            base.OnModelCreating(modelBuilder);
        }

        private static User[] SeedUserInformation()
        {
            return new User[]
              {
                new User(Guid.Parse("a996d0da-0c5e-4d3b-bcc1-3aa468f61c04"),"Behnam"),
                new User(Guid.Parse("74102bf9-83a3-453e-b3a4-391e759021bc"),"Sajjad"),
                new User(Guid.Parse("969f8d50-fa64-4bce-84f9-9a86193b99f8"),"Tooraj"),
              };
        }
    }
}
