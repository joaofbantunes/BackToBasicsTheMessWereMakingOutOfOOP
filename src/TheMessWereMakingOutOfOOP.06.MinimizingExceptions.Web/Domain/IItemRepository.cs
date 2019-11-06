using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain
{
    public interface IItemRepository
    {
        Optional<Item> Get(ItemId itemId);
    }
}