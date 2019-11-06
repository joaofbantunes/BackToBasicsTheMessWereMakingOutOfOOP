namespace TheMessWereMakingOutOfOOP._04.OOIfying.Web.Handlers
{
    public interface IRequestHandler<TIn, TOut>
    {
        TOut Handle(TIn input);
    }
}