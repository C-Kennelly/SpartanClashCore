using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRecord
{
    public class PlaylistBroker
    {
        private List<string> trackedPlaylists;

        public PlaylistBroker()
        {
            trackedPlaylists = new List<string>();


            AddRankedArenaModes();
            AddUnrankedArenaModes();
            AddWarzoneModes();
        }

        private void AddRankedArenaModes()
        {
            string slayerHopperID = "892189e9-d712-4bdb-afa7-1ccab43fbed4";
            string teamArenaHopperID = "c98949ae-60a8-43dc-85d7-0feb0b92e719";
            string haloWC2018HopperID = "5c9808b0-03a3-4577-b966-7217f9dda52d";
            string doublesHopperID = "d3bfda9f-14c2-44bc-9068-d3403bd5a059";
            string breakoutHopperID = "f72e0ef0-7c4a-4307-af78-8e38dac3fdba";
            string swatHopperID = "2323b76a-db98-4e03-aa37-e171cfbdd1a4";
            string snipersHopperID = "7b50b5d8-bfab-48b1-b868-acf65ebc39f4";

            trackedPlaylists.Add(slayerHopperID);
            trackedPlaylists.Add(teamArenaHopperID);
            trackedPlaylists.Add(haloWC2018HopperID);
            trackedPlaylists.Add(doublesHopperID);
            trackedPlaylists.Add(breakoutHopperID);
            trackedPlaylists.Add(swatHopperID);
            trackedPlaylists.Add(snipersHopperID);
        }

        private void AddUnrankedArenaModes()
        {
            string bigTeamBattleHopperID = "0bcf2be1-3168-4e42-9fb5-3551d7dbce77";
            string bigTeamBattle2HopperID = "780cc101-005c-4fca-8ce7-6f36d7156ffe";
            string bigTeamBattleHopperHopperID = "8d3beae9-e4e8-4c14-bbf0-475286ff9404";

            trackedPlaylists.Add(bigTeamBattleHopperID);
            trackedPlaylists.Add(bigTeamBattle2HopperID);
            trackedPlaylists.Add(bigTeamBattleHopperHopperID);
        }

        private void AddWarzoneModes()
        {
            string warzoneHopperID = "b50c4dc2-6c86-4d79-aa8a-23a65da292c6";
            string warzoneHopperHopperID = "ea669123-09c0-4c93-bf95-bdbe74d55e3d";
            string warzoneHopper2HopperID = "35ddd45e-065e-42fc-8c25-fe765739bf12";
            string warzoneWarlordsHopperID = "71c48987-c2c4-4c19-a111-60fd4b294e9e";

            trackedPlaylists.Add(warzoneHopperID);
            trackedPlaylists.Add(warzoneHopperHopperID);
            trackedPlaylists.Add(warzoneHopper2HopperID);
            trackedPlaylists.Add(warzoneWarlordsHopperID);

            //string warzoneTurboHopperID = "b617e24f-71aa-432b-a8a0-a9b417a3d47e";
            //string warzoneAssaultHopperID = "0e39ead4-383b-4452-bbd4-babb7becd82e";
        }

        public bool isTrackedPlaylist(string hopperIDOfGame)
        {
            return trackedPlaylists.Contains(hopperIDOfGame);
        }
    }
}
