using System;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class OrdersRepository:IAllOrders
    {
        private readonly AppDBContent _appDbContent;
        private readonly ShopBasket _shopBasket;

        public OrdersRepository(AppDBContent appDbContent, ShopBasket shopBasket)
        {
            _appDbContent = appDbContent;
            _shopBasket = shopBasket;
        }
        public void CreateOrder(Order order)
        {
            order.OrderTime=DateTime.Now;
            _appDbContent.Order.Add(order);
            _appDbContent.SaveChanges();
            var items = _shopBasket.ListShopItems;
            foreach (var el in items)
            {
                var orderDetail=new OrderDetail()
                {
                    BookID = el.Book.Id,
                    OrderID = order.Id,
                    Price = el.Book.Price
                };
                _appDbContent.OrderDetail.Add(orderDetail);
            }

            _appDbContent.SaveChanges();
        }
    }
}