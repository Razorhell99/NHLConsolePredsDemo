namespace NHLConsolePredsDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Games")]
    public partial class Games
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? GameDate { get; set; }

        public int HomeTeamID { get; set; }

        public int AwayTeamID { get; set; }

        public int HomeScore { get; set; }

        public int AwayScore { get; set; }

        public virtual Teams Team { get; set; }

        public virtual Teams Team1 { get; set; }


        public void DisplayGames()
        {
            using (var context = new NHLContext())
            {
                var query =
                    from g in context.Games
                    join t1 in context.Teams on g.AwayTeamID equals t1.ID
                    join t2 in context.Teams on g.HomeTeamID equals t2.ID
                    select new { AwayTeam = t1.TeamName,   HomeTeam = t2.TeamName, AwayScore = g.AwayScore, HomeScore = g.HomeScore };

                

                foreach (var game in query)
                {

                    Console.WriteLine("Away Team : " + game.AwayTeam + " " + game.AwayScore + "\n" + "Home Team : " + game.HomeTeam + " " + game.HomeScore);
                    Console.WriteLine("******************");
                }
            }
        }

        public void DisplayTeamLast3GamesWithGoalForAndGoalAgainst()
        {
            using (var context = new NHLContext())
            {
                string searchedTeam = "Canadiens";
                int goalScored = 0 ;
                int goalAllowed = 0 ;
                var query =
                    from g in context.Games
                    join t1 in context.Teams on g.AwayTeamID equals t1.ID
                    join t2 in context.Teams on g.HomeTeamID equals t2.ID
                    select new { AwayTeam = t1.TeamName, HomeTeam = t2.TeamName, AwayScore = g.AwayScore, HomeScore = g.HomeScore };

                foreach (var game in query)
                {
                    
                    if(game.AwayTeam == searchedTeam || game.HomeTeam == searchedTeam)
                    {
                        if(game.AwayTeam == searchedTeam)
                        {
                            goalScored += game.AwayScore;
                            goalAllowed += game.HomeScore;
                        }
                        else
                        {
                            goalScored += game.HomeScore;
                            goalAllowed += game.AwayScore;
                        }

                        Console.WriteLine("Away Team : " + game.AwayTeam + " " + game.AwayScore + "\n" + "Home Team : " + game.HomeTeam + " " + game.HomeScore);
                        Console.WriteLine("******************");
                    }


                    
                }

                Console.WriteLine($"{searchedTeam} scored {goalScored} goals during the last 3 matches");
                Console.WriteLine($"{searchedTeam} allowed {goalAllowed} goals during the last 3 matches");
            }
        }
    }
}
