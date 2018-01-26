using System;
using System.Collections.Generic;

namespace SpartanClash.Models.ClashDB
{
    public partial class TMatchparticipants
    {
        public string MatchId { get; set; }
        public string Team1Players { get; set; }
        public string Team2Players { get; set; }
        public string OtherPlayers { get; set; }
        public string DnfPlayers { get; set; }

        public TClashdevset Match { get; set; }
    }
}
