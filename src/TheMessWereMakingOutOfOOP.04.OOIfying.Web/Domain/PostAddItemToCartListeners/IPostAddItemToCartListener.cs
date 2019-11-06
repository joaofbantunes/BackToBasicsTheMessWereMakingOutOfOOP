namespace TheMessWereMakingOutOfOOP._04.OOIfying.Web.Domain.PostAddItemToCartListeners
{
    public interface IPostAddItemToCartListener
    {
        void OnAdded(Cart cart, Item item, CartItem cartItem);
    }
}