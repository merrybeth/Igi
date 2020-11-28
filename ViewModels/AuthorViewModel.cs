using System.Collections;
using System.Collections.Generic;
using Shop.Data.Models;

namespace Shop.ViewModels
{
    public class AuthorViewModel
    {
        public IEnumerable<Book> Books { set; get; }
        public Author Author { set; get; }
    }
}