using System;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain
{
    public class Item
    {
        public Item()
        {
            Id = ItemId.New();
        }
        
        public ItemId Id { get; }
    }
}