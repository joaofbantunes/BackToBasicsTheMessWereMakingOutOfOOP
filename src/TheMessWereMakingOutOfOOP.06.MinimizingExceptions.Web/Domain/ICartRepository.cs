using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain
{
    public interface ICartRepository
    {
        Optional<Cart> Get(CartId id);
        
        Cart Save(Cart cart);

        void Delete(CartId id);
    }
}