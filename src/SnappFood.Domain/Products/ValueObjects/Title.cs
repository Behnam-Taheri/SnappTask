using SnappFood.Domain.Products.Contracts;
using SnappFood.Domain.Products.Exceptions;
using SnappFood.Framework.Domain.BuildingBlocks;

namespace SnappFood.Domain.Products.ValueObjects
{
    public record Title : ValueObject
    {
        private Title() { }
       
        public Title(string value, IProductTitleDuplicateChecker duplicateChecker)
        {
            Validate(value, duplicateChecker);
            Value = value;
        }

        public string Value { get; private set; }

        private static void Validate(string value, IProductTitleDuplicateChecker duplicateChecker)
        {
            if (value.Length > 40)
                throw new LongTitleException();

            if (duplicateChecker.IsExist(value))
                throw new DuplicateTitleException();
        }
    }
}
