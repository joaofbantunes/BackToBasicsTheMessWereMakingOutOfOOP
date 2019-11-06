using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using TheMessWereMakingOutOfOOP._03.IndividualRequestHandler.Web.Data;
using TheMessWereMakingOutOfOOP._03.IndividualRequestHandler.Web.Exceptions;
using TheMessWereMakingOutOfOOP._03.IndividualRequestHandler.Web.Services;

namespace TheMessWereMakingOutOfOOP._03.IndividualRequestHandler.Web.Handlers
{
    public class AddItemToCartHandler : IRequestHandler<AddItemToCartRequest, AddItemToCartResponse>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IItemRepository _itemRepository;
        private readonly INotifier _notifier;
        private readonly ILogger<AddItemToCartHandler> _logger;

        public AddItemToCartHandler(
            ICartRepository cartRepository,
            IItemRepository itemRepository,
            INotifier notifier,
            ILogger<AddItemToCartHandler> logger)
        {
            _cartRepository = cartRepository;
            _itemRepository = itemRepository;
            _notifier = notifier;
            _logger = logger;
        }

        public AddItemToCartResponse Handle(AddItemToCartRequest input)
        {
            // do some validations
            if (input.CartId == default
                || input.ItemId == default
                || input.Quantity <= 0)
            {
                throw new ValidationException("Something isn't valid");
            }

            var cart = _cartRepository.Get(input.CartId);
            if (cart is null)
            {
                throw new NotFoundException("Couldn't find the cart");
            }

            var item = _itemRepository.Get(input.ItemId);
            if (item is null)
            {
                throw new NotFoundException("Couldn't find the item");
            }

            var cartItem = cart.Items?.FirstOrDefault(i => i.ItemId == input.ItemId);
            if (cartItem != null)
            {
                // item already on cart
                throw new ValidationException("Item already on cart");
            }

            _logger.LogInformation("Checking if can add item to cart");

            if ((item.MaximumQuantity ?? int.MaxValue) < input.Quantity)
            {
                throw new ValidationException("Quantity not allowed");
            }

            if ((item.MinimumTimeOfDayToSell ?? TimeSpan.Zero) > DateTime.Now.TimeOfDay)
            {
                throw new ValidationException("Can't buy that yet!");
            }

            _logger.LogInformation("Adding item to cart");

            // every place we want to add an item, we have the same repeated logic... 
            cartItem = new CartItem
            {
                ItemId = input.ItemId,
                Quantity = input.Quantity
            };

            if (cart.Items is null)
            {
                cart.Items = new[] { cartItem };
            }
            else
            {
                cart.Items = cart.Items.Concat(new[] { cartItem });
            }

            _cartRepository.Save(cart);

            _logger.LogInformation("Checking if need to notify someone");
            if (item.IsInWatchlist)
            {
                _notifier.Notify(input.ItemId);
            }

            // ...
            return new AddItemToCartResponse();
        }
    }
}