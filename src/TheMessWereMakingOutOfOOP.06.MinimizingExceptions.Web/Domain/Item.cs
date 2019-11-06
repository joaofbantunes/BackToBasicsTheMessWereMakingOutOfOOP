namespace TheMessWereMakingOutOfOOP._06.MinimizingExceptions.Web.Domain
{
    public class Item
    {
        public Item()
        {
            Id = ItemId.New();
        }
        
        public ItemId Id { get; }
    }
}