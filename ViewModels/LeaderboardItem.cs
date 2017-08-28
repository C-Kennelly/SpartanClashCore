using System;
using SpartanClashCore.Models;

namespace SpartanClashCore.ViewModels
{
    public class LeaderboardItem
    {
        public int rank { get; }
        public string companyName { get; }
        public string winPercent { get; }
        public int wins { get; }
        public int losses { get; }
        public int totalMatches { get; }

        public LeaderboardItem(t_companies rawItem)
        {
            rank = rawItem.rank;

            companyName = rawItem.company;

            winPercent = ConvertWinPercent(rawItem.win_percent);
            
            if(rawItem.wins == null)    {wins = 0;}
            else                        {wins = (int)rawItem.wins; }

            if (rawItem.losses == null) { losses = 0; }
            else { losses = (int)rawItem.losses; }

            if (rawItem.total_matches == null)  {totalMatches = 0;}
            else                                { totalMatches = (int)rawItem.total_matches;}

        }

        private string ConvertWinPercent(double? rawWinPercent)
        {
            if(rawWinPercent == null || rawWinPercent == 0)
            {
                return "0";
            }
            else
            {
                return (100 * Math.Round((double)rawWinPercent, 4)).ToString();
            }
        }

    }


}