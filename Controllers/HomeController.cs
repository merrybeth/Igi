using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllBooks _bookRepository;

        public HomeController(IAllBooks bookRepository)
        {
            _bookRepository = bookRepository;
        }
        

        public IActionResult Index()
        {
            var homeBooks = new HomeViewModel
            {
                MainBooks = _bookRepository.GetMainBooks
            };
            return View(homeBooks);
        }
        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}