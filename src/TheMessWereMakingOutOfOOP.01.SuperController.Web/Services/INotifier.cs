using System;

namespace TheMessWereMakingOutOfOOP._01.TheWorst.Web.Services
{
    public interface INotifier
    {
        void Notify(Guid itemId);
    }
}