using System;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain
{
    public sealed class ItemId : StronglyTypedId<ItemId>
    {
        public ItemId(Guid value) : base(value)
        {
        }

        public static ItemId New() => new ItemId(Guid.NewGuid());
    }
}