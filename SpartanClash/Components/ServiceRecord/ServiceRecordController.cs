﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ServiceRecord.ViewModels;

using SpartanClash.Models.ClashDB;
using UserBehaviorTracking;

namespace ServiceRecord
{
    public class ServiceRecordController : Controller
    {

        clashdbContext _clashdbContext;
        UserBehaviorTracker _userBehaviorTracker;

        public ServiceRecordController(clashdbContext context, UserBehaviorTracker behaviorTracker)
        {
            _clashdbContext = context;
            _userBehaviorTracker = behaviorTracker;
        }

        public ActionResult CompanyResults(string company)
        {

            List<TClashdevset> companyMatches = _clashdbContext.TClashdevset
                .Where(
                    x => x.Team1Company1 == company
                    || x.Team1Company2 == company
                    || x.Team2Company1 == company
                    || x.Team2Company2 == company
                ).OrderBy(x => x.MatchCompleteDate).ThenBy(x => x.MapId).ToList();

            List<ClanBattle> battles = new List<ClanBattle>(companyMatches.Count);

            foreach (TClashdevset match in companyMatches)
            {
                battles.Add(new ClanBattle(company, match, _clashdbContext));
            }

            if (battles.Count < 1)
            {
                return View("NoCompaniesFound");
            }
            
            _userBehaviorTracker.LogCompanySearch(company);

            return View(battles);
        }

        public ActionResult NoCompaniesFound(string company)
        {
            return View(company);
        }

       

    }
}