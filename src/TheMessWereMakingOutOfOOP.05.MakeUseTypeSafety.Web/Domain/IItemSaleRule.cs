namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain
{
    public interface IItemSaleRule
    {
        void Validate(Cart cart, Item item, int quantity);
    }
}