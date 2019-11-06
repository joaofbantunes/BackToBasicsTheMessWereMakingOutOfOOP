using TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Domain;

namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Services
{
    public interface INotifier
    {
        void Notify(ItemId itemId);
    }
}