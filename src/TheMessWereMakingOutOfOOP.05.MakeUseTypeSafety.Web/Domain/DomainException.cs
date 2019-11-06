using System;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain
{
    // in alternative to exceptions, consider a result type like:
    // https://github.com/vkhorikov/CSharpFunctionalExtensions/tree/master/CSharpFunctionalExtensions/Result
    public class DomainException: Exception 
    {
        public DomainException(ErrorDetail errorDetail)
        {
            ErrorDetail = errorDetail;
        }

        public ErrorDetail ErrorDetail { get; }
    }
}