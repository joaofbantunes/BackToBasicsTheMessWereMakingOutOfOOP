using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain.PostAddItemToCartListeners;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Handlers
{
    public class AddItemToCartHandler : IRequestHandler<AddItemToCartRequest, Result<Unit>>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IItemSaleRuleRepository _itemSaleRuleRepository;
        
        private readonly IPostAddItemToCartListener _listener;

        public AddItemToCartHandler(
            ICartRepository cartRepository,
            IItemRepository itemRepository,
            IItemSaleRuleRepository itemSaleRuleRepository,
            IPostAddItemToCartListener listener)
        {
            _cartRepository = cartRepository;
            _itemRepository = itemRepository;
            _itemSaleRuleRepository = itemSaleRuleRepository;
            _listener = listener;
        }

        public Result<Unit> Handle(AddItemToCartRequest input)
        {
            var maybeCart = _cartRepository.Get(input.CartId);
            if (!maybeCart.TryGetValue(out var cart))
            {
                return Result<Unit>.Error.NotFound.New("Couldn't find the cart");
            }
            var maybeItem = _itemRepository.Get(input.ItemId);
            if (!maybeItem.TryGetValue(out var item))
            {
                return Result<Unit>.Error.NotFound.New("Couldn't find the item");
            }

            var rules = _itemSaleRuleRepository.GetForItem(item.Id);
            var rulesResult = rules.Validate(cart, item, input.Quantity);
            
            if (rulesResult is Result<Unit>.Error)
            {
                return rulesResult;
            }
            
            var cartItemResult = cart.AddItemToCart(item, input.Quantity);
            
            if (cartItemResult is Result<CartItem>.Error cartItemErrorResult)
            {
                return cartItemErrorResult.AsErrorOf<Unit>();
            }

            _cartRepository.Save(cart);
            
            _listener.OnAdded(cart, item, cartItemResult.Value);

            return Result<Unit>.Success.New(Unit.Instance);
        }
    }
}