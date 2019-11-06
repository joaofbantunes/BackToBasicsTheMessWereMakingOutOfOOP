using System;

namespace TheMessWereMakingOutOfOOP._03.IndividualRequestHandler.Web.Handlers
{
    public class AddItemToCartRequest
    {
        public Guid CartId { get; set; }
        
        public Guid ItemId { get; set; }

        public int Quantity { get; set; }
    }
}