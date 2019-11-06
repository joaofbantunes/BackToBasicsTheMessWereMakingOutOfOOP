using System;

namespace TheMessWereMakingOutOfOOP._04.OOIfying.Web.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string message) : base(message)
        {
                
        }
    }
}