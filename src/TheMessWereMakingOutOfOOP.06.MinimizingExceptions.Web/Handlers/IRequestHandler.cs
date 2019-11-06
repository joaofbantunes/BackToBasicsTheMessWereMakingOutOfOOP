namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Handlers
{
    public interface IRequestHandler<TIn, TOut>
    {
        TOut Handle(TIn input);
    }
}