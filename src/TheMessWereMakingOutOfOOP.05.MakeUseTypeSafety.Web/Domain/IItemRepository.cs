using System;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Shared;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain
{
    public interface IItemRepository
    {
        Optional<Item> Get(ItemId itemId);
    }
}