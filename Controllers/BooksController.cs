using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class BooksController : Controller
    {
        private readonly IAllBooks _allBooks;
        private readonly IBooksCategory _allCategories;

        public BooksController(IAllBooks iAllBooks, IBooksCategory iBooksCategory)
        {
            _allBooks = iAllBooks;
            _allCategories = iBooksCategory;
        }

        [Route("Books/List")]
        [Route("Books/List/{category}")]
        public ViewResult List(string category)
        {
            var _category = category;
            IEnumerable<Book> books = null;
            var currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                books = _allBooks.Books.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("paper", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = _allBooks.Books.Where(i => i.Category.Name.Equals("Бумажные книги")).OrderBy(i => i.Id);
                    currCategory = "Бумажные книги";
                }
                else if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = _allBooks.Books.Where(i => i.Category.Name.Equals("Электронные книги")).OrderBy(i => i.Id);
                    currCategory = "Электронные книги";
                }
                else if (string.Equals("audio", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = _allBooks.Books.Where(i => i.Category.Name.Equals("Аудиокниги")).OrderBy(i => i.Id);
                    currCategory = "Аудиокниги";
                }
            }

            var bookObj = new BooksListViewModel
            {
                AllBooks = books,
                CurrCategory = currCategory
            };

            ViewBag.Title = "Страница с книгами";
            return View(bookObj);
        }
    }
}