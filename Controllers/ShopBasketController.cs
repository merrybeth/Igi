using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;
using ShopBasket = Shop.Data.Models.ShopBasket;


namespace Shop.Controllers
{
    public class ShopBasketController : Controller
    {
        private readonly IAllBooks _bookRepository;
        private readonly ShopBasket _shopBasket;

        public ShopBasketController(IAllBooks bookRepository, ShopBasket shopBasket)
        {
            _bookRepository = bookRepository;
            _shopBasket = shopBasket;
        }

        public ViewResult Index()
        {
            var items = _shopBasket.GetShopItems();
            _shopBasket.ListShopItems = items;
            var obj = new ShopBasketViwModel
            {
                shopBasket = _shopBasket
            };
            return View(obj);
        }

        public RedirectToActionResult AddToBasket(int id)
        {
            var item = _bookRepository.Books.FirstOrDefault(i => i.Id == id);
            if (item != null) _shopBasket.AddToBasket(item);

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        
        
        public ActionResult Delete(int? Id)
        {
            var item = _bookRepository.Books.FirstOrDefault(i => i.Id == Id);
            if (item != null)
            _shopBasket.DeleteFromBasket(item);
           
            var items = _shopBasket.GetShopItems();
            _shopBasket.ListShopItems = items;
            var obj = new ShopBasketViwModel
            {
                shopBasket = _shopBasket
            };
            return View("Index", obj);
        }
    }
}