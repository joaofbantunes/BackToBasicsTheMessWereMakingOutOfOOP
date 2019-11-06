using System;
using System.Collections.Generic;

namespace TheMessWereMakingOutOfOOP._01.TheWorst.Web.Data
{
    public class Cart
    {
        public Guid Id { get; set; }

        public IEnumerable<CartItem> Items { get; set; }
    }
}