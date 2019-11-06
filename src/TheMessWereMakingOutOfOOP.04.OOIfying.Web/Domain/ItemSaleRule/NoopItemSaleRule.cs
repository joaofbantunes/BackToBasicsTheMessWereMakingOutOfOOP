namespace TheMessWereMakingOutOfOOP._04.OOIfying.Web.Domain.ItemSaleRule
{
    public class NoopItemSaleRule : IItemSaleRule
    {
        public void Validate(Cart cart, Item item, int quantity)
        {
            // NOOP
        }
    }
}