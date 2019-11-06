using System;

namespace TheMessWereMakingOutOfOOP._01.TheWorst.Web.Data
{
    public interface ICartRepository
    {
        Cart Get(Guid id);
        
        Cart Save(Cart cart);

        void Delete(Guid id);
    }
}