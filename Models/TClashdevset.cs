using System;
using System.Collections.Generic;

namespace SpartanClashCore.Models
{
    public partial class TClashdevset
    {
        public TClashdevset()
        {
            TCompany2matches = new HashSet<TCompany2matches>();
        }

        public string MatchId { get; set; }
        public int? GameMode { get; set; }
        public string HopperId { get; set; }
        public string MapId { get; set; }
        public int? MapVariantResourceType { get; set; }
        public string MapVariantResourceId { get; set; }
        public int? MapVariantOwnerType { get; set; }
        public string MapVariantOwner { get; set; }
        public string GameBaseVariantId { get; set; }
        public string GameVariantResourceId { get; set; }
        public int? GameVariantResourceType { get; set; }
        public int? GameVariantOwnerType { get; set; }
        public string GameVariantOwner { get; set; }
        public DateTime? MatchCompleteDate { get; set; }
        public string MatchDuration { get; set; }
        public byte[] IsTeamGame { get; set; }
        public string SeasonId { get; set; }
        public string Team1Company1 { get; set; }
        public string Team1Company2 { get; set; }
        public string Team2Company1 { get; set; }
        public string Team2Company2 { get; set; }
        public int Team1Rank { get; set; }
        public int Team2Rank { get; set; }
        public int? Team1Score { get; set; }
        public int? Team2Score { get; set; }
        public int Status { get; set; }

        public ICollection<TCompany2matches> TCompany2matches { get; set; }
    }
}
