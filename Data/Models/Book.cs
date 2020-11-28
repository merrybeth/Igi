namespace Shop.Data.Models
{
    public class Book
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string ShortDescription { set; get; }
        public string LongDescription { set; get; }
        public string Image { set; get; }
        public ushort Price { set; get; }
        public bool IsOnMainPage { set; get; }
        public bool Available { set; get; }
        public int CategoryId { set; get; }
        public virtual Category Category { set; get; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}