namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain.ItemSaleRule
{
    public class NoopItemSaleRule : IItemSaleRule
    {
        public void Validate(Cart cart, Item item, int quantity)
        {
            // NOOP
        }
    }
}