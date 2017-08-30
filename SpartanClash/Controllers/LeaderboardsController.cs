using Microsoft.AspNetCore.Mvc;
using SpartanClash.ViewModels;

namespace SpartanClash.Controllers
{
    public class LeaderboardsController : Controller 
    {
        //GET: Leaderboards
        public ActionResult Index() 
        {
            Leaderboard leaderboard = new Leaderboard();

            return View(leaderboard);            
        }
    }
    
}