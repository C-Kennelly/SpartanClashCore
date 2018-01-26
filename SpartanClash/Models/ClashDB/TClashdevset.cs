using System;
using System.Collections.Generic;

namespace SpartanClash.Models.ClashDB
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
        public string Team1Company { get; set; }
        public int Team1Rank { get; set; }
        public uint? Team1Score { get; set; }
        public string Team1Gamertag { get; set; }
        public int? Team1Dnfcount { get; set; }
        public string Team2Company { get; set; }
        public int Team2Rank { get; set; }
        public uint? Team2Score { get; set; }
        public string Team2Gamertag { get; set; }
        public int? Team2Dnfcount { get; set; }
        public int Status { get; set; }

        public TMatchparticipants TMatchparticipants { get; set; }
        public ICollection<TCompany2matches> TCompany2matches { get; set; }
    }
}
