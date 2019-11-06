using System;
using System.Collections.Generic;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Models
{
    public class CartModel
    {
        public CartId Id { get; set; }

        public IEnumerable<CartItemModel> Items { get; set; }
    }
}
