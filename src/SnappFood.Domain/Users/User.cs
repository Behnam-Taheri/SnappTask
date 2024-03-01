using SnappFood.Framework.Domain.BuildingBlocks;

namespace SnappFood.Domain.Users
{
    public class User : AggregateRoot<Guid>
    {
        public User()
        {
            Id = Guid.NewGuid();
        }
        public string Name { get; private set; } = null!;
    }
}
