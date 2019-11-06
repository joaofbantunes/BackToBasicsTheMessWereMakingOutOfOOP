using System;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Shared;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain
{
    public class CartItem
    {
        public CartItem(ItemId itemId, int quantity)
        {
            Require.NotNull(itemId, nameof(itemId));
            
            Quantity = quantity > 0 
                ? quantity 
                : throw new ArgumentException($"{nameof(quantity)} must be greater than 0.", nameof(quantity));;
        }

        public ItemId ItemId { get; }

        public int Quantity { get; }
    }
}