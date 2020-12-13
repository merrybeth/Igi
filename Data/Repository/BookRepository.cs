using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class BookRepository : IAllBooks
    {
        private readonly AppDBContent _appDbContent;

        public BookRepository(AppDBContent appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public IEnumerable<Book> Books => _appDbContent.Book.Include(c => c.Category).Include(c => c.Author);

        public IEnumerable<Book> GetMainBooks => _appDbContent.Book.Where(p => p.IsOnMainPage).Include(c => c.Category)
            .Include(c => c.Author);

        public Book GetObjectBook(int bookId)
        {
            return _appDbContent.Book.FirstOrDefault(p => p.Id == bookId);
        }

        public void SaveBook(Book book)
        {
            if (book.Id == 0)
            {
                _appDbContent.Book.Add(book);
            }
            else
            {
                var dbEntry = _appDbContent.Book.Find(book.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = book.Name;
                    dbEntry.LongDescription = book.LongDescription;
                    dbEntry.ShortDescription = book.ShortDescription;
                    dbEntry.Price = book.Price;
                    dbEntry.Category = book.Category;
                }
            }

            _appDbContent.SaveChanges();
        }

        public Book DeleteBook(int Id)
        {
            var dbEntry = _appDbContent.Book.FirstOrDefault(book =>book.Id == Id );
            if (dbEntry != null)
            {
                _appDbContent.Book.Remove(dbEntry);
                _appDbContent.SaveChanges();
            }

            return dbEntry;
        }
    }
}