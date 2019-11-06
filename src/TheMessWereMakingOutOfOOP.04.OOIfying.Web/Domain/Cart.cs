using System;
using System.Collections.Generic;
using TheMessWereMakingOutOfOOP._04.OOIfying.Web.Exceptions;

namespace TheMessWereMakingOutOfOOP._04.OOIfying.Web.Domain
{
    public class Cart
    {
        private readonly Dictionary<Guid, CartItem> _items;

        public Cart()
        {
            Id = Guid.NewGuid();
            _items = new Dictionary<Guid, CartItem>();
        }

        public Guid Id { get; }

        public IReadOnlyCollection<CartItem> Items => _items.Values;

        public CartItem AddItemToCart(Item item, int quantity)
        {
            if (_items.ContainsKey(item.Id))
            {
                throw new ValidationException($"Item {item.Id} already in the cart.");
            }

            var cartItem = new CartItem(item.Id, quantity);
            _items.Add(item.Id, cartItem);
            return cartItem;
        }

        public CartItem UpdateItemInCart(Guid itemId, int quantity)
        {
            if (!_items.ContainsKey(itemId))
            {
                throw new ValidationException($"Item {itemId} not in the cart.");
            }

            var cartItem = new CartItem(itemId, quantity);
            _items[itemId] = cartItem;
            return cartItem;
        }

        public void RemoveItemFromCart(Guid itemId)
        {
            _items.Remove(itemId);
        }
    }
}