using System.Collections.Generic;
using System.Linq;
using SpartanClash.Models;

namespace SpartanClash.ViewModels
{
    public class Leaderboard
    {
        clashdbContext _clashdbContext;
        public List<LeaderboardItem> leaderboardItems;

        public Leaderboard(clashdbContext context)
        {
            _clashdbContext = context;

            List<TCompanies> rankedCompanies = _clashdbContext.TCompanies.Where(x => x.Rank > 0).OrderBy(x => x.Rank).ToList();

            leaderboardItems = new List<LeaderboardItem>(rankedCompanies.Count);

            foreach(TCompanies company in rankedCompanies) 
            {
                leaderboardItems.Add(new LeaderboardItem(company));
            }
          
        }

    }
}
