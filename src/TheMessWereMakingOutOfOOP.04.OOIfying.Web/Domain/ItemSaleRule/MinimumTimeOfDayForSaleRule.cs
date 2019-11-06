using System;
using TheMessWereMakingOutOfOOP._04.OOIfying.Web.Exceptions;

namespace TheMessWereMakingOutOfOOP._04.OOIfying.Web.Domain.ItemSaleRule
{
    public class MinimumTimeOfDayForSaleRule : IItemSaleRule
    {
        public MinimumTimeOfDayForSaleRule(TimeSpan minimumTimeOfDayForSale)
        {
            MinimumTimeOfDayForSale = minimumTimeOfDayForSale;
        }

        public TimeSpan MinimumTimeOfDayForSale { get; }
        
        public void Validate(Cart cart, Item item, int quantity)
        {
            if (MinimumTimeOfDayForSale  > DateTime.Now.TimeOfDay)
            {
                throw new ValidationException("Can't buy that yet!");
            }
        }
    }
}