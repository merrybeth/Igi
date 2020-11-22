using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Shop.Data.Models
{
    public class ShopBasket
    {
        private readonly AppDBContent _appDbContent;

        public ShopBasket(AppDBContent appDbContent)
        {
            this._appDbContent = appDbContent;
        }
        public string ShopBasketId { get; set; }
        public List<ShopBasketItem> ListShopItems { get; set; }

        public static ShopBasket GetBasket(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopBasketId = session.GetString("BookId") ?? Guid.NewGuid().ToString();
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

        public List<ShopBasketItem> GetShopItems()
        {
            return _appDbContent.ShopBasketItem.Where(c => c.ShopBasketId == ShopBasketId).Include(s => s.Book).ToList();
        }
        
        

    }
}