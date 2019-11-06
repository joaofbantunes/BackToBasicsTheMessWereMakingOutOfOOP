using System;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Models
{
    public class AddItemToCartModel
    {
        public ItemId ItemId { get; set; }

        public int Quantity { get; set; }
    }
}
