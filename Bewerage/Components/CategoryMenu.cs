using Bewerage.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bewerage.Components
{
    public class CategoryMenu :ViewComponent
    {
        private readonly ICategoryRepository _categoryReposity; 
        public CategoryMenu(ICategoryRepository categoryReposity)
        {
            _categoryReposity = categoryReposity; 
        }
        public IViewComponentResult Invoke()
        {
            var categories = _categoryReposity.Categories.OrderBy(n => n.CategoryName);
            return View(categories); 
        }

    }
}
