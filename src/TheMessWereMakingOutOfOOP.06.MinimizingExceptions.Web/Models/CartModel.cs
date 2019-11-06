using System.Collections.Generic;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Models
{
    public class CartModel
    {
        public CartId Id { get; set; }

        public IEnumerable<CartItemModel> Items { get; set; }
    }
}
