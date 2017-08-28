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
            
            using(var db = new clashdbContext())
            {
                List<TCompanies> rankedCompanies = db.TCompanies.Where(x => x.Rank > 0).OrderBy(x => x.Rank).ToList();

                leaderboardItems = new List<LeaderboardItem>(rankedCompanies.Count);

                foreach(TCompanies company in rankedCompanies) 
                {
                    leaderboardItems.Add(new LeaderboardItem(company));
                }
            }
          
        }

    }
}
