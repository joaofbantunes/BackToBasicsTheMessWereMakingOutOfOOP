namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Handlers
{
    public interface IRequestHandler<TIn, TOut>
    {
        TOut Handle(TIn input);
    }
}