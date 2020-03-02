using Bewerage.Data.Interfaces;
using Bewerage.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bewerage.Data.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly AppDbContext _addDbContext;
        public DrinkRepository(AppDbContext addDbContext)
        {
            _addDbContext = addDbContext; 
        }

        public IEnumerable<Drink> Drinks => _addDbContext.Drinks.Include(c => c.Category);
        public IEnumerable<Drink> PreferredDrinks => _addDbContext.Drinks.Where(p => p.IsPreferredDrink).Include(c => c.Category);

        public Drink GetDrinkById(int drinkId) => _addDbContext.Drinks.FirstOrDefault(i => i.DrinkId == drinkId); 
    }
}
