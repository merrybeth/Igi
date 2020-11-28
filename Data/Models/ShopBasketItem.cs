namespace Shop.Data.Models
{
    public class ShopBasketItem
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int Price { get; set; }

        public string ShopBasketId { get; set; }
    }
}