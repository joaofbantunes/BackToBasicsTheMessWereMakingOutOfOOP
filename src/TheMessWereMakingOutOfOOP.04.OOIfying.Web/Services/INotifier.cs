using System;

namespace TheMessWereMakingOutOfOOP._04.OOIfying.Web.Services
{
    public interface INotifier
    {
        void Notify(Guid itemId);
    }
}