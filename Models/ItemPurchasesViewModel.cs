namespace SnakeApplication.Models
{
    public class ItemPurchasesViewModel
    {
        public List<Item> ?items {  get; set; }
        public List<ItemCountViewModel>? prices { get; set; }   

    }
}
