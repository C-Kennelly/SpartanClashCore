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

        public LeaderboardItem(TCompanies rawItem)
        {
            rank = rawItem.Rank;
        
            companyName = rawItem.Company;
        
            winPercent = ConvertWinPercent(rawItem.WinPercent);
            
            if(rawItem.Wins == null)    {wins = 0;}
            else                        {wins = (int)rawItem.Wins; }
        
            if (rawItem.Losses == null) { losses = 0; }
            else { losses = (int)rawItem.Losses; }
        
            if (rawItem.TotalMatches == null)  {totalMatches = 0;}
            else                                { totalMatches = (int)rawItem.TotalMatches;}
        
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