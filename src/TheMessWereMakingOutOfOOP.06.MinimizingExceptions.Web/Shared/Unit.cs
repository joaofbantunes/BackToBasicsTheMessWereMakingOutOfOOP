namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Shared
{
    public sealed class Unit
    {
        private Unit()
        {
            
        }
        
        public static Unit Instance { get; } = new Unit();
    }
}