using System;

namespace TheMessWereMakingOutOfOOP._03.IndividualRequestHandler.Web.Data
{
    public class Item
    {
        public Guid Guid { get; set; }

        public int? MaximumQuantity { get; set; }

        public TimeSpan? MinimumTimeOfDayToSell { get; set; }

        public bool IsInWatchlist { get; set; }
    }
}