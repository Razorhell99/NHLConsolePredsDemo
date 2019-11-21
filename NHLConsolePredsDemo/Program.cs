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
            //game.DisplayGames();
            game.DisplayTeamLast3GamesWithGoalForAndGoalAgainst();
        }
    }
}
