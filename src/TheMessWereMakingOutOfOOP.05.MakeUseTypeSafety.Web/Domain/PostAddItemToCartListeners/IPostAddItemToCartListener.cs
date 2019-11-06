namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain.PostAddItemToCartListeners
{
    public interface IPostAddItemToCartListener
    {
        void OnAdded(Cart cart, Item item, CartItem cartItem);
    }
}