using System;

namespace TheMessWereMakingOutOfOOP._04.OOIfying.Web.Domain
{
    public interface ICartRepository
    {
        Cart Get(Guid id);
        
        Cart Save(Cart cart);

        void Delete(Guid id);
    }
}