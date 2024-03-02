using SnappFood.Framework.Domain.BuildingBlocks;

namespace SnappFood.Domain.Users
{
    public class User : AggregateRoot<Guid>
    {
        public User() { }
        public User(Guid id,string name)
        {
            Id = id;
            Name = name;
        }
        public string Name { get; private set; } = null!;
    }
}
