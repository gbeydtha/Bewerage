using Bewerage.Models;
using System.Collections.Generic;

namespace Bewerage.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Drink> PreferredDrinks { get; set; }
    }
}
