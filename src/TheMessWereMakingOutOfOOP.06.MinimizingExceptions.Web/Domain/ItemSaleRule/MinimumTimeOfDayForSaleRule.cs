using System;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain.ItemSaleRule
{
    public class MinimumTimeOfDayForSaleRule : IItemSaleRule
    {
        public MinimumTimeOfDayForSaleRule(TimeSpan minimumTimeOfDayForSale)
        {
            MinimumTimeOfDayForSale = minimumTimeOfDayForSale;
        }

        public TimeSpan MinimumTimeOfDayForSale { get; }
        
        public Result<Unit> Validate(Cart cart, Item item, int quantity)
        {
            if (MinimumTimeOfDayForSale  > DateTime.Now.TimeOfDay)
            {
                return Result<Unit>.Error.Invalid.New("Can't buy that yet!");
            }

            return Result<Unit>.Success.New(Unit.Instance);
        }
    }
}