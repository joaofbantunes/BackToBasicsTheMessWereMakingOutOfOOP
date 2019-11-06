namespace TheMessWereMakingOutOfOOP._05.MakeUseTypeSafety.Web.Shared
{
    public sealed class Unit
    {
        private Unit()
        {
            
        }
        
        public static Unit Instance { get; } = new Unit();
    }
}