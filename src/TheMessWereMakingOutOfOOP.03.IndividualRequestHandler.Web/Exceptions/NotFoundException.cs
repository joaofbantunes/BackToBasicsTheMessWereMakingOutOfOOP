using System;

namespace TheMessWereMakingOutOfOOP._03.IndividualRequestHandler.Web.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string message) : base(message)
        {
                
        }
    }
}