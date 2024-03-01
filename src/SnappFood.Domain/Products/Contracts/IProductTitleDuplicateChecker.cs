using SnappFood.Framework.Domain.BuildingBlocks;

namespace SnappFood.Domain.Products.Contracts
{
    public interface IProductTitleDuplicateChecker : IDomainService
    {
        bool IsExist(string title);
    }
}
