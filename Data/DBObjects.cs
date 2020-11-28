using System.Collections.Generic;
using System.Linq;
using Shop.Data.Models;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void initial(AppDBContent content)
        {
            var abc = new Author()
            {
                DateOfBirth = "01.02.2001",
                DateOfDeath = "02.03.2020",
                Name = "Жак", Surname = "Фреско",
                LifeDescription = "загадочник"
            };

            if (!content.Author.Any())
            {
                content.AddRange(abc);
            }
            
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));
            if (!content.Book.Any())
                content.AddRange(
                    new Book
                    {
                        Name = "Преступление и наказание", ShortDescription = "вяамвамя", LongDescription = "фммфцмфук",
                        Image = "/img/crime.jpg",
                        Price = 450, IsOnMainPage = true, Available = true,
                        Category = Categories["Бумажные книги"],
                        Author = abc
                    },
                    new Book
                    {
                        Name = "Гарри Поттер", ShortDescription = "вяамвамя", LongDescription = "фммфцмфук",
                        Image = "/img/harry.jpg",
                        Price = 450, IsOnMainPage = true, Available = true,
                        Category = Categories["Электронные книги"], Author = abc
                    }
                );
            content.SaveChanges();
        }

        private static Dictionary<string, Category> _categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    var list = new[]
                    {
                        new Category {Name = "Бумажные книги", Description = "Традиционные книги в переплете"},
                        new Category
                        {
                            Name = "Электронные книги", Description = "Книги, которые вы можете скачать на устройство"
                        },
                        new Category {Name = "Аудиокниги", Description = "Книги, которые вы можете прослушать"}
                    };

                    _categories = new Dictionary<string, Category>();
                    foreach (var el in list)
                        _categories.Add(el.Name, el);
                }

                return _categories;
            }
        }
    }
}