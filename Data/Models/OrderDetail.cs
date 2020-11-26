namespace Shop.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public int BookID { get; set; }
        public uint Price { get; set; }
        public virtual Book Book { get; set; }
        public virtual Order Order{ get; set; }
    }
}