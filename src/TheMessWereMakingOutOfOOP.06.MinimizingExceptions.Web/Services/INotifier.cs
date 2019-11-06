using TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain;

namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Services
{
    public interface INotifier
    {
        void Notify(ItemId itemId);
    }
}