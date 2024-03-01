using SnappFood.Framework.Domain.BuildingBlocks;

namespace SnappFood.Domain.Users
{
    public class User : AggregateRoot<Guid>
    {
        public string Name { get; set; } = null!;
    }
}
