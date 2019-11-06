using System;

namespace TheMessWereMakingOutOfOOP._04.OOIfying.Web.Domain
{
    public interface IItemSaleRuleRepository
    {
        IItemSaleRule GetForItem(Guid itemId);
    }
}