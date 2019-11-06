using System;

namespace TheMessWereMakingOutOfOOP._01.TheWorst.Web.Data
{
    public class Item
    {
        public Guid Id { get; set; }

        public int? MaximumQuantity { get; set; }

        public TimeSpan? MinimumTimeOfDayToSell { get; set; }

        public bool IsInWatchlist { get; set; }
    }
}