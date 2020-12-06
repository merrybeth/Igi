using System.Collections.Generic;
using Shop.Data.Models;

namespace Shop.ViewModels
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> AllBooks { get; set; }
        public string CurrCategory { get; set; }
    }
}