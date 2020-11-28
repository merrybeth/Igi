using System.Collections.Generic;
using Shop.Data.Models;

namespace Shop.Data.Interfaces
{
    public interface IAllBooks
    {
        IEnumerable<Book> Books { get; }
        IEnumerable<Book> GetMainBooks { get; }
        Book GetObjectBook(int bookId);
    }
}