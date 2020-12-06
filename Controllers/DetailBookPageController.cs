using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class DetailBookPageController : Controller
    {
        private readonly IAllBooks _bookRepository;
        private Book _book;

        public DetailBookPageController(IAllBooks bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public ViewResult Index(int id)
        {
            var item = _bookRepository.Books.FirstOrDefault(i => i.Id == id);
            if (item != null) _book = item;
            var obj = new PageViewModel
            {
                Book = _book
            };
            return View(obj);
        }
    }
}