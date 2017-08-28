using System.Collections.Generic;
using System.Linq;
using SpartanClashCore.Models;

namespace SpartanClashCore.ViewModels
{
    public class Leaderboard
    {
        public List<LeaderboardItem> leaderboardItems;

        public Leaderboard()
        {
            using (var db = new clashdbEntities()) 
            {
                List<t_companies> rankedCompanies = db.t_companies.Where(x => x.rank > 0).OrderBy(x => x.rank).ToList();

                leaderboardItems = new List<LeaderboardItem>(rankedCompanies.Count);

                foreach(t_companies company in rankedCompanies) 
                {
                    leaderboardItems.Add(new LeaderboardItem(company));
                }
            }
        }

    }
}
