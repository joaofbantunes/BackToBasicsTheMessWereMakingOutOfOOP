using System;
using System.Collections.Generic;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Services;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain.PostAddItemToCartListeners
{
    public class WatchlistNotifierListener : IPostAddItemToCartListener
    {
        private readonly INotifier _notifier;
        private readonly HashSet<ItemId> _itemsInWatchlist;

        public WatchlistNotifierListener(INotifier notifier, IReadOnlyCollection<ItemId> itemsInWatchlist)
        {
            _notifier = notifier;
            _itemsInWatchlist = new HashSet<ItemId>(itemsInWatchlist);
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