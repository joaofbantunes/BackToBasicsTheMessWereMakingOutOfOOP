namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain.PostAddItemToCartListeners
{
    public interface IPostAddItemToCartListener
    {
        void OnAdded(Cart cart, Item item, CartItem cartItem);
    }
}