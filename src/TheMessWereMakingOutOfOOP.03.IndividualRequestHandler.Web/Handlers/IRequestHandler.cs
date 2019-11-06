namespace TheMessWereMakingOutOfOOP._03.IndividualRequestHandler.Web.Handlers
{
    public interface IRequestHandler<TIn, TOut>
    {
        TOut Handle(TIn input);
    }
}