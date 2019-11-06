using System;
using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain
{
    public sealed class DomainException<TValue>: Exception 
    {
        public DomainException(Result<TValue>.Error errorDetail)
        {
            ErrorDetail = errorDetail;
        }

        public Result<TValue>.Error ErrorDetail { get; }
    }
}