using System;

namespace TheMessWereMakingOutOfOOP._03.IndividualRequestHandler.Web.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
                
        }
    }
}