using System;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain
{
    public interface IItemSaleRuleRepository
    {
        IItemSaleRule GetForItem(ItemId itemId);
    }
}