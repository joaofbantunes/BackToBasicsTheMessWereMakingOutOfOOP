using Microsoft.Extensions.Logging;
using TheMessWereMakingOutOfOOP._04.OOIfying.Web.Domain;
using TheMessWereMakingOutOfOOP._04.OOIfying.Web.Domain.ItemSaleRule;
using TheMessWereMakingOutOfOOP._04.OOIfying.Web.Domain.PostAddItemToCartListeners;
using TheMessWereMakingOutOfOOP._04.OOIfying.Web.Exceptions;

namespace TheMessWereMakingOutOfOOP._04.OOIfying.Web.Handlers
{
    public class AddItemToCartHandler : IRequestHandler<AddItemToCartRequest, AddItemToCartResponse>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IItemSaleRuleRepository _itemSaleRuleRepository;
        private readonly IPostAddItemToCartListener _listener;
        private readonly ILogger<AddItemToCartHandler> _logger;

        public AddItemToCartHandler(
            ICartRepository cartRepository,
            IItemRepository itemRepository,
            IItemSaleRuleRepository itemSaleRuleRepository,
            IPostAddItemToCartListener listener,
            ILogger<AddItemToCartHandler> logger)
        {
            _cartRepository = cartRepository;
            _itemRepository = itemRepository;
            _itemSaleRuleRepository = itemSaleRuleRepository;
            _listener = listener;
            _logger = logger;
        }

        public AddItemToCartResponse Handle(AddItemToCartRequest input)
        {
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

            var rules = _itemSaleRuleRepository.GetForItem(item.Id);
            rules.Validate(cart, item, input.Quantity);

            var cartItem = cart.AddItemToCart(item, input.Quantity);

            _cartRepository.Save(cart);

            _listener.OnAdded(cart, item, cartItem);

            // ...
            return new AddItemToCartResponse();
        }
    }
}