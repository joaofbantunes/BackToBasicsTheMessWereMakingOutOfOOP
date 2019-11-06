using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain.ItemSaleRule
{
    public class NoopItemSaleRule : IItemSaleRule
    {
        private static readonly Result<Unit> NoopResult = Result<Unit>.Success.New(Unit.Instance);

        public Result<Unit> Validate(Cart cart, Item item, int quantity)
            => NoopResult;
    }
}