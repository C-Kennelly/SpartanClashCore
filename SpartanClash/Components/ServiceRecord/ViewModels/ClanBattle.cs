using System;
using SpartanClash.Models.ClashDB;
using SpartanClash.Data;

namespace ServiceRecord.ViewModels
{
    public class ClanBattle
    {
        const string missingCompanyValue = "NOCOMPANYFOUND";
        const string printableMissingCompanyValue = "[randoms]";

        public string primaryCompany { get; set; }
        public string allyHeader;
        public string enemyHeader;

        public int score { get; set; }
        public int enemyScore { get; set; }
        public DateTime matchDate { get; set; }

        public bool isWin { get; set; }
        public bool isClanBattle { get; set; }

        private int team { get; set; }
        private string allyCompany { get; set; }
        private string enemyCompany1 { get; set; }
        private string enemyCompany2 { get; set; }

        clashdbContext _clashdbContext;

        public ClanBattle(clashdbContext context)
        {
            _clashdbContext = context;
        }

        public ClanBattle(string companyName, TClashdevset match, clashdbContext context)
        {
            _clashdbContext = context;

            primaryCompany = companyName;

            DetermineTeam(match);
            DetermineTeamSpecificComponents(match);

            SetHeader(out allyHeader, primaryCompany, allyCompany);
            SetHeader(out enemyHeader, enemyCompany1, enemyCompany2);

            matchDate = (DateTime)match.MatchCompleteDate;

            SetSortingFlags();
        }

        private void SetSortingFlags()
        {
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

        public int GetTeam()
        {
            return team;
        }

        private void DetermineTeam(TClashdevset match)
        {
            if (primaryCompany == match.Team1Company1 || primaryCompany == match.Team1Company2)
            { team = 1; }
            else { team = 2; }
        }

        private void DetermineTeamSpecificComponents(TClashdevset match)
        {
            if (team == 1) //Company is on team 1
            {
                score = (int)match.Team1Score;
                enemyScore = (int)match.Team2Score;
                enemyCompany1 = match.Team2Company1;
                enemyCompany2 = match.Team2Company2;

                if (primaryCompany == match.Team1Company1)
                {
                    allyCompany = match.Team1Company2;
                }
                else
                {
                    allyCompany = match.Team1Company2;
                }
            }
            else //Company is on team 2.
            {
                score = (int)match.Team2Score;
                enemyScore = (int)match.Team1Score;

                enemyCompany1 = match.Team1Company1;
                enemyCompany2 = match.Team1Company2;

                if (primaryCompany == match.Team2Company1)
                {
                    allyCompany = match.Team2Company2;
                }
                else
                {
                    allyCompany = match.Team2Company1;
                }

            }

        }

        private void SetHeader(out string header, string mainCompany, string secondaryCompany)
        {
            if (mainCompany == missingCompanyValue)
            {
                header = printableMissingCompanyValue;
            }
            else
            {
                if (secondaryCompany == missingCompanyValue)
                {
                    header = mainCompany;
                }
                else
                {
                    header = mainCompany + " & " + secondaryCompany;
                }
            }
        }

    }
}