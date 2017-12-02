using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedViews.Models;

namespace Home
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return RedirectToAction(nameof(DailyLoop.DailyLoopController.Index), "DailyLoop");
            return View();
        }

        public IActionResult Autocomplete(string term) 
        {
            var items = new[] {"Apple", "Pear", "Banana", "Pineapple", "Peach"};

            var filteredItems = items.Where(
                item => item.IndexOf(term, 
                StringComparison.InvariantCultureIgnoreCase) >= 0
            );
            return Json(filteredItems);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
