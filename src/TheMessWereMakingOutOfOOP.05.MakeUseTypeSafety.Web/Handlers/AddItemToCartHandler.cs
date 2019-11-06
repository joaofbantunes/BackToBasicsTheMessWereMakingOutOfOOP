using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain.PostAddItemToCartListeners;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Shared;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Handlers
{
    public class AddItemToCartHandler : IRequestHandler<AddItemToCartRequest, Unit>
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

        public Unit Handle(AddItemToCartRequest input)
        {
            var maybeCart = _cartRepository.Get(input.CartId);
            var cart = maybeCart.ValueOr(
                () => throw new DomainException(ErrorDetail.NotFound.New("Couldn't find the cart")));

            var maybeItem = _itemRepository.Get(input.ItemId);
            var item = maybeItem.ValueOr(
                () => throw new DomainException(ErrorDetail.NotFound.New("Couldn't find the item")));

            var rules = _itemSaleRuleRepository.GetForItem(item.Id);
            rules.Validate(cart, item, input.Quantity);
            
            var cartItem = cart.AddItemToCart(item, input.Quantity);

            _cartRepository.Save(cart);

            _listener.OnAdded(cart, item, cartItem);

            return Unit.Instance;
        }
    }
}