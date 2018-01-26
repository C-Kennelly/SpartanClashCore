using Newtonsoft.Json;

namespace SpartanClash.Models.ClashDB.Extensions
{
    public class CustomTeamEntry
    {
        public string teamId;
        public string teamType;

        public CustomTeamEntry()
        {

        }

        public CustomTeamEntry(string teamName, string teamTypeName)
        {
            teamId = teamName;
            teamType = teamTypeName;
        }

        public string GetJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
