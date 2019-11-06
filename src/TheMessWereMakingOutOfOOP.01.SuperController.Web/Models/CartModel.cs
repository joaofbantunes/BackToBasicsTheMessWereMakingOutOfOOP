using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMessWereMakingOutOfOOP._01.TheWorst.Web.Models
{
    public class CartModel
    {
        public Guid Id { get; set; }

        public IEnumerable<CartItemModel> Items { get; set; }
    }
}
