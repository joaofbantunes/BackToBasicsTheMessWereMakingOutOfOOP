using System;

namespace TheMessWereMakingOutOfOOP._03.IndividualRequestHandler.Web.Models
{
    public class AddItemToCartModel
    {
        public Guid ItemId { get; set; }

        public int Quantity { get; set; }
    }
}
