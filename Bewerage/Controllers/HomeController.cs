using Bewerage.Data.Interfaces;
using Bewerage.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Bewerage.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDrinkRepository _drinkRepository; 
        public HomeController(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository; 
        }
        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                PreferredDrinks = _drinkRepository.PreferredDrinks
            }; 
            return View(homeViewModel);
        }

    }
}
