namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain.ItemSaleRule
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
                throw new DomainException(ErrorDetail.Invalid.New("Quantity not allowed"));
            }
        }
    }
}