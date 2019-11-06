using System;

namespace TheMessWereMakingOutOfOOP._02.SuperService.Web.Data
{
    public interface IItemRepository
    {
        Item Get(Guid itemId);
    }
}