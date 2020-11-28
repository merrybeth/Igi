using System.Collections.Generic;
using Shop.Data.Models;

namespace Shop.Data.Interfaces
{
    public interface IBooksCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}