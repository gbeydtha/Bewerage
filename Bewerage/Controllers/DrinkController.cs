using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bewerage.Data.Interfaces;
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
        public ViewResult List()
        {
            ViewBag.XYZ = "OH, Core";
            DrinkListViewModel vm = new DrinkListViewModel();
            vm.Drinks = _drinkRepository.Drinks;
            vm.CurrentCategory = "Drink Category";
            return View(vm);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}