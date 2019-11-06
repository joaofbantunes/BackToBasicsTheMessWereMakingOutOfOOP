using System;

namespace TheMessWereMakingOutOfOOP._04.OOIfying.Web.Domain
{
    public interface IItemRepository
    {
        Item Get(Guid itemId);
    }
}