using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bewerage.Data.Interfaces;
using Bewerage.Models;
using Bewerage.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Bewerage.Controllers
{
    public class DrinkController : Controller
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IDrinkRepository _drinkRepository;

        public DrinkController(ICategoryRepository categoryRepository, IDrinkRepository drinkRepository)
        {
            _categoryRepository = categoryRepository;
            _drinkRepository = drinkRepository;
        }
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Drink> drinks;
            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                drinks = _drinkRepository.Drinks.OrderBy(n => n.DrinkId);
                currentCategory = "All drinks";
            }
            else
            {
                if(string.Equals("Alcoholic", _category, StringComparison.OrdinalIgnoreCase))
                {
                    drinks = _drinkRepository.Drinks.Where(P => P.Category.CategoryName.Equals("Alcoholic")).OrderBy(n => n.DrinkId); 
                }
                else
                    drinks = _drinkRepository.Drinks.Where(P => P.Category.CategoryName.Equals("Non-alcoholic")).OrderBy(n => n.DrinkId);

                currentCategory = category; 
            }


            var  vm = new DrinkListViewModel() {
                Drinks = drinks,
                CurrentCategory = currentCategory
            };

            return View(vm);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}