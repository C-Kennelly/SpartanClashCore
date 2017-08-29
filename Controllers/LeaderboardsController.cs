using Microsoft.AspNetCore.Mvc;
using SpartanClashCore.ViewModels;

namespace SpartanClashCore.Controllers
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