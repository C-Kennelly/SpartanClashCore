﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpartanClash.Models.ClashDB;
using Microsoft.AspNetCore.Mvc;

namespace Leaderboards
{
    public class LeaderboardsController : Controller
    {
        clashdbContext _clashdbContext;

        static Random random = new Random();

        public LeaderboardsController(clashdbContext context)
        {
            _clashdbContext = context;
        }

        public IActionResult ViewRandomRankedTeam()
        {
            string featuredCompany = "";


            List<TCompanies> rankedCompanies = _clashdbContext.TCompanies.Where(x => x.Rank > 0).OrderBy(x => x.Rank).ToList();

            if (rankedCompanies.Count > 0)
            {
                featuredCompany = rankedCompanies[random.Next(rankedCompanies.Count)].Company.ToString();
            }
            else
            {
                featuredCompany = _clashdbContext.TCompanies.FirstOrDefault().Company.ToString();
            }

            return RedirectToAction("CompanyCards", "ServiceRecord", new { company = featuredCompany } );
        }
    }
}