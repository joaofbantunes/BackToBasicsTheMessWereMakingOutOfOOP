using System;
using System.Collections.Generic;
using TheMessWereMakingOutOfOOP._04.OOIfying.Web.Services;

namespace TheMessWereMakingOutOfOOP._04.OOIfying.Web.Domain.PostAddItemToCartListeners
{
    public class WatchlistNotifierListener : IPostAddItemToCartListener
    {
        private readonly INotifier _notifier;
        private readonly HashSet<Guid> _itemsInWatchlist;

        public WatchlistNotifierListener(INotifier notifier, IReadOnlyCollection<Guid> itemsInWatchlist)
        {
            _notifier = notifier;
            _itemsInWatchlist = new HashSet<Guid>(itemsInWatchlist);
        }

        public void OnAdded(Cart cart, Item item, CartItem cartItem)
        {
            if (_itemsInWatchlist.Contains(item.Id))
            {
                _notifier.Notify(item.Id);
            }
        }
    }
}