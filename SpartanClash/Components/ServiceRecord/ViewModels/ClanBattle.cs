using System;
using System.Linq;
using SpartanClash.Models.ClashDB;


namespace ServiceRecord.ViewModels
{
    public class ClanBattle
    {
        const string missingCompanyValue = "0";
        const string printableMissingCompanyValue = "[randoms]";

        public string primaryCompany { get; set; }
        public string allyHeader;
        public string enemyHeader;
        

        public int score { get; set; }
        public int enemyScore { get; set; }
        public DateTime matchDate { get; set; }

        public bool isWin { get; set; }
        public bool isClanBattle { get; set; }
        public string gameMode { get; set; }

        public string mapName { get; set; }
        private string mapImageURL { get; set; }

        private int team { get; set; }
        private string enemyCompany { get; set; }

        private string matchId;
        private string gamertagFromCompany { get; set; }

        clashdbContext _clashdbContext;

        public ClanBattle(clashdbContext context)
        {
            _clashdbContext = context;
        }

        public ClanBattle(string companyName, TClashdevset match, clashdbContext context)
        {
            _clashdbContext = context;

            primaryCompany = companyName;

            matchId = match.MatchId;

            DetermineTeam(match);
            DetermineTeamSpecificComponents(match);

            allyHeader = companyName;
            SetEnemyHeader(out enemyHeader, enemyCompany);

            TMapmetadata metadataRecord = _clashdbContext.TMapmetadata.Find(match.MapId);
            mapName = metadataRecord.PrintableName;
            mapImageURL = metadataRecord.ImageUrl;

            matchDate = (DateTime)match.MatchCompleteDate;

            gameMode = SetGameMode(match);

            SetSortingFlags();
        }

        public string GetWaypointDetailsURL()
        {
            return WaypointURLBuilder.GetWaypointURL(gameMode, matchId, gamertagFromCompany);
        }

        private string SetGameMode(TClashdevset match)
        {
            //Can we pull this from an API instead of hard coding?
            //https://developer.haloapi.com/docs/services/58acdf27e2f7f71ad0dad84b/operations/58acdf28e2f7f70db4854b3b
            //   Error = 0, 
            //   Arena = 1, 
            //   Campaign = 2, 
            //   Custom = 3, 
            //   Warzone = 4,
            //   CustomLocal = 6.

            if (match.GameMode == 1)
            {
                return "Arena";
            }
            else if(match.GameMode == 4)
            {
                return "Warzone";
            }
            else
            {
                return "Custom";
            }
        }

        private void SetSortingFlags()
        {
            //draws count as a loss
            if (score > enemyScore)
            {
                isWin = true;
            }
            else
            {
                isWin = false;
            }

            if (enemyHeader == printableMissingCompanyValue)
            {
                isClanBattle = false;
            }
            else
            {
                isClanBattle = true;
            }
        }

        public string GetMapImageURL()
        {
            return mapImageURL;
        }

        public int GetTeam()
        {
            return team;
        }

        private void DetermineTeam(TClashdevset match)
        {
            if (primaryCompany == match.Team1Company)
            { team = 1; }
            else { team = 2; }
        }

        private void DetermineTeamSpecificComponents(TClashdevset match)
        {
            TMatchparticipants matchParticipantRecord = _clashdbContext.TMatchparticipants.Find(match.MatchId);


            if (team == 1) //Company is on team 1
            {
                gamertagFromCompany = match.Team1Gamertag;
                enemyCompany = match.Team2Company;

                if (match.Team1Score != null)
                {
                    score = (int)match.Team1Score;
                } else { score = 0; }

                if(match.Team2Score != null)
                {
                    enemyScore = (int)match.Team2Score;
                } else { enemyScore = 0; }

                
            }
            else //Company is on team 2.
            {
                gamertagFromCompany = match.Team2Gamertag;
                enemyCompany = match.Team1Company;

                if (match.Team2Score != null)
                {
                    score = (int)match.Team2Score;
                } else { score = 0; }

                if (match.Team1Score != null)
                {
                    enemyScore = (int)match.Team1Score;
                } else { enemyScore = 0; }
            }

        }

        private void SetEnemyHeader(out string header, string enemyCompanyId)
        {
            if (enemyCompanyId == missingCompanyValue)
            {
                header = printableMissingCompanyValue;
            }
            else
            {
                TCompanies companyRecord = _clashdbContext.TCompanies.Where(record => record.CompanyId == enemyCompanyId).FirstOrDefault();

                if (companyRecord != null)
                {
                    header = companyRecord.CompanyName;

                }
                else
                {
                    header = printableMissingCompanyValue;
                }
            
            }
        }

    }
}