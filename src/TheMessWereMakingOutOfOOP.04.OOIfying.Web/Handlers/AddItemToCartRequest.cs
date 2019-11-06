using System;

namespace TheMessWereMakingOutOfOOP._04.OOIfying.Web.Handlers
{
    public class AddItemToCartRequest
    {
        public AddItemToCartRequest(Guid cartId, Guid itemId, int quantity)
        {
            CartId = cartId;
            ItemId = itemId;
            Quantity = quantity;
        }

        public Guid CartId { get; }
        
        public Guid ItemId { get; }

        public int Quantity { get; }
    }
}