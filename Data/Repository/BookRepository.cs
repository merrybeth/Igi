using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class BookRepository:IAllBooks
    {
        private readonly AppDBContent _appDbContent;

        public BookRepository(AppDBContent appDbContent)
        {
            this._appDbContent = appDbContent;
        }

        public IEnumerable<Book> Books => _appDbContent.Book.Include(c => c.Category);

        public IEnumerable<Book> GetMainBooks => _appDbContent.Book.Where(p => p.IsOnMainPage).Include(c => c.Category);

        public Book GetObjectBook(int bookId) => _appDbContent.Book.FirstOrDefault(p => p.Id == bookId);

    }
}