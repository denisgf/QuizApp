using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
        Category GetCategoryByName(string categoryName);
    }
}
