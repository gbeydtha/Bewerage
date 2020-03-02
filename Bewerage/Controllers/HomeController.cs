﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bewerage.Models;
using Bewerage.Data.Interfaces;
using Bewerage.ViewModel;

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

        #region old Code


        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        #endregion
    }
}
