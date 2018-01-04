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
            //TODO - set this per company or user session?
            DateTime lastRefreshDate = GetLastRefreshDate();

            List<TClashdevset> companyMatches = _clashdbContext.TClashdevset
                .Where(
                    x => (x.Team1Company1 == company
                            || x.Team1Company2 == company
                            || x.Team2Company1 == company
                            || x.Team2Company2 == company
                            )
                    && x.MatchCompleteDate > lastRefreshDate
                ).ToList();//.OrderBy(x => x.MatchCompleteDate).ThenBy(x => x.MapId).ToList();

            List<ClanBattle> battles = new List<ClanBattle>(companyMatches.Count);

            foreach (TClashdevset match in companyMatches)
            {
                battles.Add(new ClanBattle(company, match, _clashdbContext));
            }

            _userBehaviorTracker.LogCompanySearch(company);

            if (battles.Count < 1)
            {
                return View("NoCompaniesFound", company);
            }

            return View( battles.OrderByDescending(battle => battle.isClanBattle).ThenBy(battle => battle.enemyHeader) );
        }

        public ActionResult NoCompaniesFound(string company)
        {
            return View(company);
        }

        private DateTime GetLastRefreshDate()
        {
            //Default day is the day before Halo 5 release date (thus includes all matches)
            DateTime defaultDate = new DateTime(2015, 10, 26);

            DateTime result = _clashdbContext.TClashmetadata.Where(x => x.Id == 0).Select(x => x.DataRefreshDate).FirstOrDefault();

            if (result == null)
            {
                result = defaultDate;
            }

            return result;
        }
    }
}