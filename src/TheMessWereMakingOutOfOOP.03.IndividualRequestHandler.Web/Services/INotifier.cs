using System;

namespace TheMessWereMakingOutOfOOP._03.IndividualRequestHandler.Web.Services
{
    public interface INotifier
    {
        void Notify(Guid itemId);
    }
}