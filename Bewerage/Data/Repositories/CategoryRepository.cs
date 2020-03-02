using Bewerage.Data.Interfaces;
using Bewerage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bewerage.Data.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly AppDbContext _addDbContext;
        public CategoryRepository(AppDbContext addDbContext)
        {
            _addDbContext = addDbContext; 
        }

        public IEnumerable<Category> Categories => _addDbContext.Categories; 
    }
}
