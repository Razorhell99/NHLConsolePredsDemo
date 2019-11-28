using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLConsolePredsDemo
{
    public class TempScoreTable
    {
        public int ID { get; set; }
        public int SearchedTeamID { get; set; }
        public int? GoalScored { get; set; }
        public int? GoalAllowed { get; set; }

        public TempScoreTable(int searchedTeamID, int goalScored, int goalAllowed)
        {
            SearchedTeamID = searchedTeamID;
            GoalScored = goalScored;
            GoalAllowed = goalAllowed;
        }
        public TempScoreTable()
        {

        }

        public void WriteGoalsToTeamsTable(int teamID)
        {
            
            int goalScored = 0;
            int goalAllowed = 0;
            Repository repo = new Repository();
            var games = repo.DisplayLast3MatchForSearchedTeam(teamID);

            foreach (var game in games)
            {
                if (teamID == game.AwayTeamID)
                {
                    goalScored += game.AwayScore;
                    goalAllowed += game.HomeScore;
                }
                else if (teamID == game.HomeTeamID)
                {
                    goalScored += game.HomeScore;
                    goalAllowed += game.AwayScore;
                }
            }
            TempScoreTable temp = new TempScoreTable(teamID, goalScored, goalAllowed);
            temp.UpdateTeamsTable();
            Console.WriteLine(" Scored :" + goalScored + " Allowed:" + goalAllowed);


        }

        public void WriteAllGoalsToTeamsTable()
        {
            
            for (int i = 2; i < 33; i++)
            {
                WriteGoalsToTeamsTable(i);
            }
        }

        public void UpdateTeamsTable()
        {
            using (var context = new NHLContext())
            {
                var resultID = context.TempScoreTable.SingleOrDefault(t => t.SearchedTeamID == SearchedTeamID);
                if(resultID != null)
                {
                    resultID.GoalAllowed = GoalAllowed;
                    resultID.GoalScored = GoalScored;
                    context.SaveChanges();
                }

            }
        }


       
    }
}
