using System.Collections.Generic;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain.PostAddItemToCartListeners
{
    public class CompositePostAddItemToCartListener : IPostAddItemToCartListener
    {
        private readonly IReadOnlyCollection<IPostAddItemToCartListener> _listeners;

        public CompositePostAddItemToCartListener(IReadOnlyCollection<IPostAddItemToCartListener> listeners)
        {
            _listeners = listeners;
        }
        
        public void OnAdded(Cart cart, Item item, CartItem cartItem)
        {
            foreach (var listener in _listeners)
            {
                listener.OnAdded(cart, item, cartItem);
            }
        }
    }
}