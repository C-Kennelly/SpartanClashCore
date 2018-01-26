using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRecord.ViewModels
{
    public static class WaypointURLBuilder
    {
        private static string baseUrl = "https://www.halowaypoint.com";

        
        public static string GetWaypointURL(string modeName, string matchId, string gamertagFromTeam, string language = "en-us", string game = "halo-5-guardians", string platform = "xbox-one")
        {
            string prefix = GetGameAndPlatformPrefix(language, game, platform);
            string suffix = GetMatchSuffix(modeName, matchId, gamertagFromTeam);

            return prefix + suffix;
        }


        private static string GetGameAndPlatformPrefix(string language, string game, string platform)
        {
            string languageFragment = ("/" + language);
            string gameFragment = ("/games/" + game);
            string platformFramgment = ("/" + platform);

            return baseUrl + languageFragment + gameFragment + platformFramgment;
        }

        private static string GetMatchSuffix(string modeName, string matchId, string gamertag)
        {
            string modeFragment = ("/mode/" + modeName);
            string matchesFragment = ("/matches/" + matchId);
            string playerFragement = ("/players/" + gamertag);

            return modeFragment + matchesFragment + playerFragement;
        }


    }
}
