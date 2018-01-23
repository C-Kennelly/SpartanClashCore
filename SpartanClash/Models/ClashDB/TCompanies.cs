using System;
using System.Collections.Generic;

namespace SpartanClash.Models.ClashDB
{
    public partial class TCompanies
    {
        public TCompanies()
        {
            TCompany2matches = new HashSet<TCompany2matches>();
        }

        public string Company { get; set; }
        public int Rank { get; set; }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
        public int? TotalMatches { get; set; }
        public double? WinPercent { get; set; }
        public int TimesSearched { get; set; }

        public ICollection<TCompany2matches> TCompany2matches { get; set; }
    }
}