using System.Collections.Generic;
using SpartanClash.Models.ClashDB.Extensions;
using Newtonsoft.Json;

namespace SpartanClash.Models.ClashDB
{
    public partial class TMatchparticipants
    {

        public List<string> ToListOfGamertags()
        {
            List<string> result = new List<string>();

            result.AddRange(GetTeamGamertagsFromField(Team1Players));
            result.AddRange(GetTeamGamertagsFromField(Team2Players));
            result.AddRange(GetTeamGamertagsFromField(OtherPlayers));
            result.AddRange(GetTeamGamertagsFromField(DnfPlayers));

            return result;
        }

        public List<string> GetTeamGamertagsFromField(string JSONParticipantField)
        {
            List<string> result = new List<string>();

            if (JSONParticipantField != null)
            {
                List<MatchParticipantEntry> workingList = JsonConvert.DeserializeObject<List<MatchParticipantEntry>>(JSONParticipantField);
                foreach (MatchParticipantEntry entry in workingList)
                {
                    result.Add(entry.gamertag);
                }
            }

            return result;
        }




    }
}

