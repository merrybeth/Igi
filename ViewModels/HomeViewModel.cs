using System.Collections;
using System.Collections.Generic;
using Shop.Data.Models;

namespace Shop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Book> MainBooks { set; get; }
    }
}