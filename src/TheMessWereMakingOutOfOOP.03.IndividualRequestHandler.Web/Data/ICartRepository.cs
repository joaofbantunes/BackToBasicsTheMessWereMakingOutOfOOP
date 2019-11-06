using System;

namespace TheMessWereMakingOutOfOOP._03.IndividualRequestHandler.Web.Data
{
    public interface ICartRepository
    {
        Cart Get(Guid id);
        
        Cart Save(Cart cart);

        void Delete(Guid id);
    }
}