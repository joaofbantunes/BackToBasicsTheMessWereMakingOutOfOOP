using System;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Shared;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain
{
    public sealed class ItemId : StronglyTypedId<ItemId>
    {
        public ItemId(Guid value) : base(value)
        {
        }

        public static ItemId New() => new ItemId(Guid.NewGuid());
    }
}