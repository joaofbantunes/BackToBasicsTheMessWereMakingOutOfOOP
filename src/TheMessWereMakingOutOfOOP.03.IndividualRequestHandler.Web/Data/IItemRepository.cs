using System;

namespace TheMessWereMakingOutOfOOP._03.IndividualRequestHandler.Web.Data
{
    public interface IItemRepository
    {
        Item Get(Guid itemId);
    }
}