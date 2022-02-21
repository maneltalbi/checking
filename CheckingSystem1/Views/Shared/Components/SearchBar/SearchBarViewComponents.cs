using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckingSystem1.Views.Shared.Components.SearchBar
{
    public class SearchBarViewComponents : ViewComponent
    {
        public  SearchBarViewComponents()
        {
        }
        public IViewComponentResult Invoke(Spager SearchPager)
        {
            return View("Default", SearchPager);
        }

    }
}
