using System;

namespace TheMessWereMakingOutOfOOP._04.OOIfying.Web.Domain
{
    public class Item
    {
        public Item()
        {
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; }
        
    }
}