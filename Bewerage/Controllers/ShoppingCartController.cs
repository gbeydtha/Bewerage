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
    public class ShoppingCartController : Controller
    {
        private readonly IDrinkRepository _drinkREpository;
        private readonly ShoppingCart _shoppingCart; 

        public ShoppingCartController(IDrinkRepository drinkREpository, ShoppingCart shoppingCart)
        {
            _drinkREpository = drinkREpository;
            _shoppingCart = shoppingCart; 
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var scVM = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(scVM);

        }

        public RedirectToActionResult AddToShoppingCart(int drinkId)
        {
            var selectedDrink = _drinkREpository.Drinks.FirstOrDefault(d => d.DrinkId == drinkId); 
            if(selectedDrink != null)
            {
                _shoppingCart.AddToCart(selectedDrink, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int drinkId)
        {
            var selectedDrink = _drinkREpository.Drinks.FirstOrDefault(d => d.DrinkId == drinkId);
            if (selectedDrink != null)
            {
                _shoppingCart.RemoveFromCart(selectedDrink);
            }

            return RedirectToAction("Index");
        }
        
    }
}