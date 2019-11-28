using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLConsolePredsDemo
{
    public class GamesRepository
    {
        

        public void GetTopScoringTeams()
        {
            using(var context = new NHLContext())
            {
                var query = context.TempScoreTable
                    .Join(context.Teams,
                    tempScore => tempScore.SearchedTeamID,
                    teams => teams.ID,
                    (tempScore, teams) => new { TempScoreTable = tempScore, Teams = teams })
                    .OrderByDescending(c => c.TempScoreTable.GoalScored)
                    .Take(3);

                //foreach (var team in query)
                //{
                //    Console.WriteLine(team.Teams.TeamName + " " + team.TempScoreTable.GoalScored);

                //}

                Console.WriteLine(query.GetType());
                
            }


        }


        //public void DisplayTopScoringTeams()
        //{
        //    var test = GetTopScoringTeams();
        //    foreach (var game in test)
        //    {

        //    }
        //}
    }
}
