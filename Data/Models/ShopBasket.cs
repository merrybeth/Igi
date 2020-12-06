using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.Data.Models
{
    public class ShopBasket
    {
        private readonly AppDBContent _appDbContent;

        public ShopBasket(AppDBContent appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public string ShopBasketId { get; set; }
        public List<ShopBasketItem> ListShopItems { get; set; }

        public static ShopBasket GetBasket(IServiceProvider services)
        {
            var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            var shopBasketId = session.GetString("BookId") ?? Guid.NewGuid().ToString();
            session.SetString("BookId", shopBasketId);
            return new ShopBasket(context) {ShopBasketId = shopBasketId};
        }

        public void AddToBasket(Book book)
        {
            _appDbContent.ShopBasketItem.Add(new ShopBasketItem
            {
                ShopBasketId = ShopBasketId,
                Book = book,
                Price = book.Price
            });
            _appDbContent.SaveChanges();
        }

        public void DeleteFromBasket(Book book)
        {
            var abc = _appDbContent.ShopBasketItem.Where(x => x.ShopBasketId == ShopBasketId && x.Book == book)
                .ToList();

            foreach (var item in abc) _appDbContent.ShopBasketItem.Remove(item);


            _appDbContent.SaveChanges();
        }

        public List<ShopBasketItem> GetShopItems()
        {
            return _appDbContent.ShopBasketItem.Where(c => c.ShopBasketId == ShopBasketId).Include(s => s.Book)
                .ToList();
        }
    }
}