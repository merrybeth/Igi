using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class BooksController:Controller
    {
        private readonly IAllBooks _allBooks;
        private readonly IBooksCategory _allCategories;

        public BooksController(IAllBooks iAllBooks, IBooksCategory iBooksCategory)
        {
            _allBooks = iAllBooks;
            _allCategories = iBooksCategory;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Страница с книгами";
            BooksListViewModel obj= new BooksListViewModel();
            obj.AllBooks = _allBooks.Books;
            obj.CurrCategory = "Книги";
            return View(obj);
        }
    }
}