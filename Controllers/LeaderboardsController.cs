using Microsoft.AspNetCore.Mvc;
using SpartanClashCore.ViewModels;

namespace SpartanClashCore.Controllers
{
    public class LeadboardsController : Controller 
    {
        //GET: Leaderboards
        [HandleError]
        public ActionResult Index() 
        {
            Leaderboard leaderboard = new Leaderboard();

            return View(leaderboard);            
        }
    }
    
}