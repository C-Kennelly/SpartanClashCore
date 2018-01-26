using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpartanClash.Data;
using SpartanClash.Models.ClashDB;
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
            return View();
        }

        public IActionResult CompanyAutocomplete(string term) 
        {

            using (var db = _clashdbContext)
            {
                //var companies = db.TCompanies.SelectMany(record => record.Company).ToArray();

                var companies = from t in db.TCompanies
                                select t.CompanyName;

                var filteredCompanies = companies.Where(
                    company => company.IndexOf(term,
                    StringComparison.InvariantCultureIgnoreCase) >= 0
                ).ToList();

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
