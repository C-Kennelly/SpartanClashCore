using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpartanClash.Data;
using SpartanClash.Models;
using SharedViews.Models;

namespace Home
{
    public class HomeController : Controller
    {
        clashdbContext _clashdbContext;

        public HomeController(clashdbContext context)
        {
            _clashdbContext = context;
        }

        public IActionResult Index()
        {
            //return RedirectToAction(nameof(DailyLoop.DailyLoopController.Index), "DailyLoop");
            return View();
        }

        public IActionResult CompanyAutocomplete(string term) 
        {
            //var items = new[] {"Apple", "Pear", "Banana", "Pineapple", "Peach"};
            //
            //var filteredItems = items.Where(
            //    item => item.IndexOf(term,
            //    StringComparison.InvariantCultureIgnoreCase) >= 0
            //);

            using (var db = _clashdbContext)
            {
                var companies = db.TCompanies.ToArray();

                var filteredCompanies = companies.Where(
                    company => company.Company.IndexOf(term, 
                    StringComparison.InvariantCultureIgnoreCase) >= 0
                );

                return Json(filteredCompanies);
            }
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
