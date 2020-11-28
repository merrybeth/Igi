using System.Collections.Generic;

namespace Shop.Data.Models
{
    public class Category
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public List<Book> Books { set; get; }
    }
}