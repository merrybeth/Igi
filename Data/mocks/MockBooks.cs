using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Shop.Data.Interfaces;
using Shop.Data.Models;
namespace Shop.Data.mocks
{
    public class MockBooks:IAllBooks {
        private readonly IBooksCategory _booksCategory=new MockCategory();
        public IEnumerable<Book> Books =>
            new List<Book>
            {
                new Book
                {
                    Name = "Преступление и наказание", ShortDescription = "вяамвамя", LongDescription = "фммфцмфук", Image = "/img/crime.jpg",
                    Price = 450, IsOnMainPage = true, Available = true,
                    Category = _booksCategory.AllCategories.First()
                },
                new Book
                {
                Name = "Гарри Поттер", ShortDescription = "вяамвамя", LongDescription = "фммфцмфук", Image = "/img/harry.jpg",
                Price = 450, IsOnMainPage = true, Available = true,
                Category = _booksCategory.AllCategories.First()
                }
                
            };

        public IEnumerable<Book> GetMainBooks { get; set; }
        public Book GetObjectBook(int bookId)
        {
            throw new System.NotImplementedException();
        }
    }
}