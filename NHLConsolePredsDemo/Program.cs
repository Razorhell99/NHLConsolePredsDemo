using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLConsolePredsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Games game = new Games();
            Repository repo = new Repository();
            TempScoreTable temp = new TempScoreTable();
            GamesRepository gamesRep = new GamesRepository();
            //game.DisplayGames();
            //game.DisplayTeamLast3GamesWithGoalForAndGoalAgainst();
            //game.FindHighestScoringTeamLast3Games();
            //game.DisplayLast3MatchForSearchedTeam();
            //repo.AddGamestoDatabase();
            //repo.AddMultipleGames();
            //temp.WriteAllTeamsToTempTable();
            gamesRep.GetTopScoringTeams();
        }
    }
}
