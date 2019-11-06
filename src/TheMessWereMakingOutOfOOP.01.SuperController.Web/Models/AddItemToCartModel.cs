using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMessWereMakingOutOfOOP._01.TheWorst.Web.Models
{
    public class AddItemToCartModel
    {
        public Guid ItemId { get; set; }

        public int Quantity { get; set; }
    }
}
