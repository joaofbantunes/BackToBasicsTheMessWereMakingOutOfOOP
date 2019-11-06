using TheMessWereMakingOutOfOOP._04.OOIfying.Web.Exceptions;

namespace TheMessWereMakingOutOfOOP._04.OOIfying.Web.Domain.ItemSaleRule
{
    public class MaximumQuantityPerSaleRule : IItemSaleRule
    {
        public MaximumQuantityPerSaleRule(int maximumQuantityPerSale)
        {
            MaximumQuantityPerSale = maximumQuantityPerSale;
        }

        public int MaximumQuantityPerSale { get; }
        
        public void Validate(Cart cart, Item item, int quantity)
        {
            if (MaximumQuantityPerSale < quantity)
            {
                throw new ValidationException("Quantity not allowed");
            }
        }
    }
}