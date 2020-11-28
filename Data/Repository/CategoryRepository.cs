using System.Collections.Generic;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class CategoryRepository : IBooksCategory
    {
        private readonly AppDBContent _appDbContent;

        public CategoryRepository(AppDBContent appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public IEnumerable<Category> AllCategories => _appDbContent.Category;
    }
}