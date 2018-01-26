using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ServiceRecord.ViewModels;

using SpartanClash.Models.ClashDB;
using UserBehaviorTracking;
using Notification;

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

        public ActionResult CompanyCards(string company)
        {
            string companyId = "-1";

            TCompanies companyRecord = _clashdbContext.TCompanies.Where(record => record.CompanyName == company).FirstOrDefault();
                
            if(companyRecord != null)
            {
                companyId = companyRecord.CompanyId;

            }

            const int arenaGameModeNumber = 1;
            const int warzoneGameModeNumber = 4;

            List<TClashdevset> companyMatches = _clashdbContext.TClashdevset
                .Where( //Arena or Warzome match, with company participation.
                    (x => (x.GameMode == arenaGameModeNumber 
                                || x.GameMode == warzoneGameModeNumber)
                          && (x.Team1Company == companyId 
                                || x.Team2Company == companyId)
                    )
                ).ToList();

            List<ClanBattle> battles = new List<ClanBattle>(companyMatches.Count);

            foreach (TClashdevset match in companyMatches)
            {
                bool isTeamGame = BitConverter.ToBoolean(match.IsTeamGame, 0);
             
                ClanBattle battle = new ClanBattle(company, match, _clashdbContext);

                if(isTeamGame)
                {
                    if (battle.allyHeader != battle.enemyHeader)
                    {

                        battles.Add(battle);
                    }
                    else
                    {
                        //Company fought itself, we would need Fireteams to reflect this without looking silly.
                    }
                }

                
            }

            _userBehaviorTracker.LogCompanySearch(company);

            if (battles.Count < 1)
            {
                return View("NoCompaniesFound", company);
            }

            return View( battles.OrderByDescending(battle => battle.isClanBattle).ThenBy(battle => battle.enemyHeader).ThenByDescending(battle => battle.matchDate) );
        }

        public ActionResult NoCompaniesFound(string company)
        {
            return View(company);
        }


        //Good code, but not in use until the logged in component.
        //Need to decide if we're pulling the last refresh date, or if we're really after a user's last log on date.

        //DateTime lastRefreshDate = GetLastRefreshDate();
        //ViewData["LastRefreshDate"] = lastRefreshDate.ToShortDateString();

        /*  
        private DateTime GetLastRefreshDate()
        {
            //Default day is the day before Halo 5 release date (thus includes all matches)
            DateTime defaultDate = new DateTime(2015, 10, 26);

            DateTime result = _clashdbContext.TClashmetadata.Where(x => x.Id == "active").Select(x => x.DataRefreshDate).FirstOrDefault();

            if (result == null)
            {
                result = defaultDate;
            }

            return result;
        }
        */
    }
}