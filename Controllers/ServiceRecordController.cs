using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SpartanClashCore.Models;
using SpartanClashCore.ViewModels;

namespace SpartanClashCore.Controllers
{
    public class ServiceRecordController : Controller
    {
        //GET: ServiceRecord
        public ActionResult Index() 
        {
            using(var db = new clashdbEntities()) 
            {
                CompanyRegistry companyRegistry = new CompanyRegistry();

                return View(companyRegistry);
            }
        }

        public ActionResult CompanyResults(string company) 
        {
            using(var db = new clashdbEntities()) 
            {
                List<t_clashdevset> companyMatches = db.t_clashdevset
                    .Where(
                        x => x.Team1_Company1 == company
                        || x.Team1_Company2 == company
                        || x.Team2_Company1 == company
                        || x.Team2_Company2 == company
                    ).OrderBy(x => x.MatchCompleteDate).ThenBy(x => x.MapId).ToList();
            
                List<ClanBattle> battles = new List<ClanBattle>(companyMatches.Count);

                foreach(t_clashdevset match in companyMatches) 
                {
                    battles.Add(new ClanBattle(company, match));
                }

                if(battles.Count < 1)
                {
                    return View("NoCompaniesFound");
                }

                return View(battles);
            }
        }

        public ActionResult NoCompaniesFound(string company)
        {
            return View(company);
        }
    }
}