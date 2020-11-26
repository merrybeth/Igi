using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using ViewResult = System.Web.Mvc.ViewResult;

namespace Shop.Controllers
{
    public class OrderController:Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly ShopBasket _shopBasket;

        public OrderController(IAllOrders allOrders, ShopBasket shopBasket)
        {
            _allOrders = allOrders;
            _shopBasket = shopBasket;
        }

        public IActionResult Checkout()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopBasket.ListShopItems = _shopBasket.GetShopItems();
            if (_shopBasket.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "Корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                _allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}