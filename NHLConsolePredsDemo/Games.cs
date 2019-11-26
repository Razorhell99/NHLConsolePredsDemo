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

        public Games()
        {

        }
        public Games(DateTime gameDate, int homeTeamID, int awayTeamID, int homeScore, int awayScore)
        {
            GameDate = gameDate;
            HomeTeamID = homeTeamID;
            AwayTeamID = awayTeamID;
            HomeScore = homeScore;
            AwayScore = awayScore;
        }
        


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


        public void DisplayLast3MatchForSearchedTeam()
        {
            using (var context = new NHLContext())
            {
                int searchedTeamID = 23;
                int goalScored = 0;
                int goalAllowed = 0;
                var query = context.Games.Where(g => g.AwayTeamID.Equals(searchedTeamID) || g.HomeTeamID.Equals(searchedTeamID))
                    .OrderByDescending(g => g.GameDate)
                    .Take(3);
              
                    

                foreach (var game in query)
                {
                    if(game.AwayTeamID == searchedTeamID)
                    {
                        goalScored += game.AwayScore;
                        goalAllowed += game.HomeScore;
                        
                    }
                    else if(game.HomeTeamID == searchedTeamID)
                    {
                        goalScored += game.HomeScore;
                        goalAllowed += game.AwayScore;
                       
                    }
                    
                    
                }
                Console.WriteLine(goalScored + " " + goalAllowed);
            }
        }

        public void DisplayTeamLast3GamesWithGoalForAndGoalAgainst()
        {
            using (var context = new NHLContext())
            {
                Console.WriteLine("Please enter the team name : ");
                string searchedTeam = Console.ReadLine().ToString();
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

        public void FindHighestScoringTeamLast3Games()
        {

            using (var context = new NHLContext())
            {
                
                int searchedTeamID = 2;
                int goalScored = 0;
                int goalAllowed = 0;
               
                var query =
                    from g in context.Games
                    join t1 in context.Teams on g.AwayTeamID equals t1.ID
                    join t2 in context.Teams on g.HomeTeamID equals t2.ID
                    select new { AwayTeamID = t1.ID, HomeTeamID = t2.ID, AwayScore = g.AwayScore, HomeScore = g.HomeScore, HomeTeam = t1.TeamName, AwayTeam = t2.TeamName };

                foreach (var game in query)
                {
                    for(int i = searchedTeamID; i < 33;i++)
                    {
                        if (game.AwayTeamID == searchedTeamID || game.HomeTeamID == searchedTeamID)
                        {
                            
                            if (game.AwayTeamID == searchedTeamID)
                            {
                                goalScored += game.AwayScore;
                                goalAllowed += game.HomeScore;
                                //check team id
                                //write scores in temp table 
                            }
                            else
                            {
                                goalScored += game.HomeScore;
                                goalAllowed += game.AwayScore;
                            }
                            var scoreTable = context.TempScoreTable.Find(searchedTeamID);
                            scoreTable.GoalScored = goalScored;
                            scoreTable.GoalAllowed = goalAllowed;

                           
                           
                        }
                        
                       
                       
                        Console.WriteLine(searchedTeamID + goalScored + goalAllowed);
                    }


                }
                //context.SaveChanges();
                //Console.WriteLine($"{searchedTeamID} scored {goalScored} goals during the last 3 matches");
                //Console.WriteLine($"{searchedTeamID} allowed {goalAllowed} goals during the last 3 matches");


            }


        }
    }
}
