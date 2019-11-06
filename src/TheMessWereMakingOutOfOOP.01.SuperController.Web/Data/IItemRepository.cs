using System;

namespace TheMessWereMakingOutOfOOP._01.TheWorst.Web.Data
{
    public interface IItemRepository
    {
        Item Get(Guid itemId);
    }
}