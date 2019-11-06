using System;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain
{
    public sealed class CartId : StronglyTypedId<CartId>
    {
        public CartId(Guid value) : base(value)
        {
        }

        public static CartId New() => new CartId(Guid.NewGuid());
    }
}