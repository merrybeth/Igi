using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shop.Data.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class HomeController:Controller
    {
        private readonly IAllBooks _bookRepository;

        public HomeController(IAllBooks bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public ViewResult Index()
        {
            var homeBooks = new HomeViewModel
            {
                MainBooks = _bookRepository.GetMainBooks
            };
            return View(homeBooks);
        }
    }
}