using System;
using System.Collections.Generic;
using System.Linq;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Shared;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain
{
    public class Cart
    {
        private readonly Dictionary<ItemId, CartItem> _items;

        private Cart(CartId cartId, IReadOnlyCollection<CartItem> cartItems)
        {
            Require.NotNull(cartId, nameof(cartId));
            Require.NotNull(cartItems, nameof(cartItems));
            
            Id = cartId;
            _items = cartItems.ToDictionary(i => i.ItemId, i => i);
        }
        
        public static Cart New()
            => new Cart(CartId.New(), Array.Empty<CartItem>());
        
        public static Cart From(CartId cartId, IReadOnlyCollection<CartItem> cartItems)
            => new Cart(cartId, cartItems);
        
        public CartId Id { get; }

        public IReadOnlyCollection<CartItem> Items => _items.Values;

        public CartItem AddItemToCart(Item item, int quantity)
        {
            if (_items.ContainsKey(item.Id))
            {
                throw new DomainException(ErrorDetail.Invalid.New($"Item {item.Id} already in the cart."));
            }

            var cartItem = new CartItem(item.Id, quantity);
            _items.Add(item.Id, cartItem);
            return cartItem;
        }
        
        public CartItem UpdateItemInCart(ItemId itemId, int quantity)
        {
            if (!_items.ContainsKey(itemId))
            {
                throw new DomainException(ErrorDetail.Invalid.New($"Item {itemId} not in the cart.")) ;
            }
            
            var cartItem = new CartItem(itemId, quantity);
            _items[itemId] = cartItem;
            return cartItem;
        }

        public void RemoveItemFromCart(ItemId itemId)
        {
            _items.Remove(itemId);
        }
    }
}