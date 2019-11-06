using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain.ItemSaleRule
{
    public class MaximumQuantityPerSaleRule : IItemSaleRule
    {
        public MaximumQuantityPerSaleRule(int maximumQuantityPerSale)
        {
            MaximumQuantityPerSale = maximumQuantityPerSale;
        }

        public int MaximumQuantityPerSale { get; }
        
        public Result<Unit> Validate(Cart cart, Item item, int quantity)
        {
            if (MaximumQuantityPerSale < quantity)
            {
                return Result<Unit>.Error.Invalid.New("Quantity not allowed");
            }
            
            return Result<Unit>.Success.New(Unit.Instance);
        }
    }
}