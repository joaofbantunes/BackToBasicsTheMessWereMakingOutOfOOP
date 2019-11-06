using System;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Shared;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain
{
    public interface ICartRepository
    {
        Optional<Cart> Get(CartId id);
        
        Cart Save(Cart cart);

        void Delete(CartId id);
    }
}