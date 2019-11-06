using System;
using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Shared;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain
{
    public sealed class CartId : StronglyTypedId<CartId>
    {
        public CartId(Guid value) : base(value)
        {
        }

        public static CartId New() => new CartId(Guid.NewGuid());
    }
}