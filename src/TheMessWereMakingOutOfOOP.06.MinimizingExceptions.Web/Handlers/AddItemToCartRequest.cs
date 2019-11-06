using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Handlers
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