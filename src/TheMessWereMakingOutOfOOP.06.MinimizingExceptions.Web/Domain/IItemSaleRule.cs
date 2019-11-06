using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain
{
    public interface IItemSaleRule
    {
        Result<Unit> Validate(Cart cart, Item item, int quantity);
    }
}