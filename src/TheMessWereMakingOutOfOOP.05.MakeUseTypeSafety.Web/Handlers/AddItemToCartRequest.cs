using System;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Handlers
{
    public class AddItemToCartRequest
    {
        public AddItemToCartRequest(CartId cartId, ItemId itemId, int quantity)
        {
            CartId = cartId;
            ItemId = itemId;
            Quantity = quantity;
        }

        public CartId CartId { get; }
        
        public ItemId ItemId { get; }

        public int Quantity { get; }
    }
}