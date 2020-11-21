using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void initial(AppDBContent content)
        {

            if(!content.Category.Any())
                content.Category.AddRange(Categories.Select(c=>c.Value));
            if (!content.Book.Any())
            {
                content.AddRange(
                    new Book
                    {
                        Name = "Преступление и наказание", ShortDescription = "вяамвамя", LongDescription = "фммфцмфук", Image = "/img/crime.jpg",
                        Price = 450, IsOnMainPage = true, Available = true,
                        Category = Categories["Бумажные книги"]
                    },
                    new Book
                    {
                        Name = "Гарри Поттер", ShortDescription = "вяамвамя", LongDescription = "фммфцмфук", Image = "/img/harry.jpg",
                        Price = 450, IsOnMainPage = true, Available = true,
                        Category = Categories["Электронные книги"]
                    }
                );
            }
            content.SaveChanges();
        }

        private static Dictionary<string, Category> _categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    var list = new Category[]
                    {
                        new Category {Name = "Бумажные книги", Description = "Традиционные книги в переплете"},
                        new Category
                        {
                            Name = "Электронные книги", Description = "Книги, которые вы можете скачать на устройство"
                        },
                        new Category {Name = "Аудиокниги", Description = "Книги, которые вы можете прослушать"}
                    };
                    
                    _categories = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        _categories.Add(el.Name, el);
                }

                return _categories;
            }
        }
    }
}