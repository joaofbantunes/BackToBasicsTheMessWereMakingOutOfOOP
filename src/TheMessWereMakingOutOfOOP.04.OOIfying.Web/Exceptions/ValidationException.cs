using System;

namespace TheMessWereMakingOutOfOOP._04.OOIfying.Web.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
                
        }
    }
}