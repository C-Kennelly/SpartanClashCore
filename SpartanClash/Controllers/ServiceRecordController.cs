using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SpartanClash.Models;
using SpartanClash.ViewModels;
/*
namespace SpartanClash.Controllers
{
    public class ServiceRecordController : Controller
    {

        clashdbContext _clashdbContext;

        public ServiceRecordController(clashdbContext context) 
        {
            _clashdbContext = context;
        }
        
        //GET: ServiceRecord
        public ActionResult Index() 
        {
            CompanyRegistry companyRegistry = new CompanyRegistry(_clashdbContext);

            return View(companyRegistry);
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

            foreach(TClashdevset match in companyMatches) 
            {
                battles.Add(new ClanBattle(company, match, _clashdbContext));
            }

            if(battles.Count < 1)
            {
                return View("NoCompaniesFound");
            }

            return View(battles);
        }

        public ActionResult NoCompaniesFound(string company)
        {
            return View(company);
        }
 
    }
}
*/
