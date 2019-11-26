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

        public TempScoreTable()
        {
           
        }
    }
}
