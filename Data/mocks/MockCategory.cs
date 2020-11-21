using System.Collections.Generic;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.mocks
{
    public class MockCategory:IBooksCategory
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{Name = "Бумажные книги", Description = "Традиционные книги в переплете"},
                new Category{Name = "Электронные книги", Description = "Книги, которые вы можете скачать на устройство"},
                new Category{Name = "Аудиокниги", Description = "Книги, которые вы можете прослушать"}
            };
    }
}