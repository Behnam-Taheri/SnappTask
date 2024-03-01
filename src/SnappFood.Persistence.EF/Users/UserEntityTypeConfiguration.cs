using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SnappFood.Domain.Orders;
using SnappFood.Domain.Users;

namespace SnappFood.Persistence.EF.Users
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();


            builder.HasMany(typeof(Order)).WithOne().HasForeignKey(nameof(Order.UserId));
        }
    }
}
