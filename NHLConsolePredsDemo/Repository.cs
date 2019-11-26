using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLConsolePredsDemo
{
    public class Repository
    {
        public void AddGamestoDatabase()
        {
            using (var context = new NHLContext())
            {
                //TODO - refactor converting string searched team to teams.ID into a fucntion to be reused elsewhere
                Console.WriteLine("Enter game date : ");
                DateTime gameDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter Home Team : ");
                string homeTeam = Console.ReadLine();
                var homeTeamID = from t in context.Teams
                                 where t.TeamName == homeTeam
                                 select t.ID;
                
                Console.WriteLine("Enter Away Team : ");
                string awayTeam = Console.ReadLine();
                var awayTeamID = from t in context.Teams
                                 where t.TeamName == awayTeam
                                 select t.ID;
                Console.WriteLine("Enter Home Score : ");
                int homeScore = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Away Score : ");
                int awayScore = int.Parse(Console.ReadLine());

                var game = new Games(gameDate, homeTeamID.First(), awayTeamID.First(), homeScore, awayScore);

                
                context.Games.Add(game);

                context.SaveChanges();

            }

        }

        public void AddMultipleGames()
        {
            string answer = "yes";
            do
            {
                AddGamestoDatabase();
                Console.WriteLine("Do you wan to add another game?");
                answer = Console.ReadLine();
                if(answer == "no")
                {
                    answer = "no";
                }
                
            }
            while (answer == "yes");
        }


    }
}
