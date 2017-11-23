using Microsoft.AspNetCore.Mvc;
using SpartanClash.Models;
using Leaderboards.ViewModels;

namespace Leaderboards
{
    public class LeaderboardsController : Controller 
    {

        clashdbContext _clashdbContext;
        //GET: Leaderboards

        public LeaderboardsController(clashdbContext context)
        {
            _clashdbContext = context;
        }
        public ActionResult Index() 
        {
            Leaderboard leaderboard = new Leaderboard(_clashdbContext);

            return View(leaderboard);            
        }
    }   
}
