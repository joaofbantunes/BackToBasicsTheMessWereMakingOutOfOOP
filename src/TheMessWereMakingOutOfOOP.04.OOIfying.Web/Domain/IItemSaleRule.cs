namespace TheMessWereMakingOutOfOOP._04.OOIfying.Web.Domain
{
    public interface IItemSaleRule
    {
        void Validate(Cart cart, Item item, int quantity);
    }
}